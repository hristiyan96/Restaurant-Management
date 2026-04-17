using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Kitchen,Administrator,User")]
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;

        public KitchenController(ApplicationDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(string filter = "active", int page = 1, int pageSize = 9)
        {
            page = Math.Max(1, page);
            pageSize = Math.Clamp(pageSize, 6, 24);

            IQueryable<Order> ordersQuery = _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Waiter)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem);

            IQueryable<Order> filteredQuery;

            switch (filter.ToLower())
            {
                case "pending":
                    filteredQuery = ordersQuery
                        .Where(o => o.Status == OrderStatus.Pending)
                        .OrderBy(o => o.CreatedAt);
                    break;
                case "preparing":
                    filteredQuery = ordersQuery
                        .Where(o => o.Status == OrderStatus.Preparing)
                        .OrderBy(o => o.CreatedAt);
                    break;
                case "ready":
                    filteredQuery = ordersQuery
                        .Where(o => o.Status == OrderStatus.Ready)
                        .OrderBy(o => o.CreatedAt);
                    break;
                case "all":
                    filteredQuery = ordersQuery
                        .OrderByDescending(o => o.CreatedAt);
                    break;
                default: // "active"
                    filteredQuery = ordersQuery
                        .Where(o => o.Status == OrderStatus.Pending || o.Status == OrderStatus.Preparing)
                        .OrderBy(o => o.CreatedAt);
                    break;
            }

            var totalOrdersForFilter = await filteredQuery.CountAsync();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalOrdersForFilter / (double)pageSize));
            page = Math.Min(page, totalPages);

            var orders = await filteredQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Statistics
            var todayStart = DateTime.UtcNow.Date;
            var todayEnd = todayStart.AddDays(1);
            var stats = new
            {
                Pending = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Pending),
                Preparing = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Preparing),
                Ready = await _context.Orders.CountAsync(o => o.Status == OrderStatus.Ready),
                Today = await _context.Orders.CountAsync(o => o.CreatedAt >= todayStart && o.CreatedAt < todayEnd)
            };

            ViewBag.Filter = filter;
            ViewBag.Stats = stats;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalOrdersForFilter = totalOrdersForFilter;

            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartPreparing(Guid orderId)
        {
            try
            {
                if (orderId == Guid.Empty)
                {
                    return Json(new { success = false, message = "Невалидна поръчка." });
                }

                await _orderService.UpdateOrderStatusAsync(orderId, OrderStatus.Preparing);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkReady(Guid orderId)
        {
            try
            {
                if (orderId == Guid.Empty)
                {
                    return Json(new { success = false, message = "Невалидна поръчка." });
                }

                await _orderService.UpdateOrderStatusAsync(orderId, OrderStatus.Ready);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkItemReady(Guid orderItemId)
        {
            try
            {
                if (orderItemId == Guid.Empty)
                {
                    return Json(new { success = false, message = "Невалиден артикул." });
                }

                var orderItem = await _context.OrderItems.FindAsync(orderItemId);
                if (orderItem != null)
                {
                    orderItem.IsReady = true;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Json(new { success = false, message = "Артикулът не е намерен." });
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
