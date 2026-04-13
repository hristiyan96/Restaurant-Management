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

        public async Task<IActionResult> Index(string filter = "active")
        {
            IQueryable<Order> ordersQuery = _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Waiter)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem);

            List<Order> orders;
            
            switch (filter.ToLower())
            {
                case "pending":
                    orders = await ordersQuery
                        .Where(o => o.Status == OrderStatus.Pending)
                        .OrderBy(o => o.CreatedAt)
                        .ToListAsync();
                    break;
                case "preparing":
                    orders = await ordersQuery
                        .Where(o => o.Status == OrderStatus.Preparing)
                        .OrderBy(o => o.CreatedAt)
                        .ToListAsync();
                    break;
                case "ready":
                    orders = await ordersQuery
                        .Where(o => o.Status == OrderStatus.Ready)
                        .OrderBy(o => o.CreatedAt)
                        .ToListAsync();
                    break;
                case "all":
                    orders = await ordersQuery
                        .OrderByDescending(o => o.CreatedAt)
                        .Take(50)
                        .ToListAsync();
                    break;
                default: // "active"
                    orders = await ordersQuery
                        .Where(o => o.Status == OrderStatus.Pending || o.Status == OrderStatus.Preparing)
                        .OrderBy(o => o.CreatedAt)
                        .ToListAsync();
                    break;
            }

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

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> StartPreparing(Guid orderId)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, OrderStatus.Preparing);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MarkReady(Guid orderId)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, OrderStatus.Ready);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MarkItemReady(Guid orderItemId)
        {
            try
            {
                var orderItem = await _context.OrderItems.FindAsync(orderItemId);
                if (orderItem != null)
                {
                    orderItem.IsReady = true;
                    await _context.SaveChangesAsync();
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
