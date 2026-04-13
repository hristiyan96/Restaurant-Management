using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get today's date range
            var today = DateTime.UtcNow.Date;
            var todayEnd = today.AddDays(1);

            // Get this week's date range
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var weekEnd = weekStart.AddDays(7);

            // Get this month's date range
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1);

            // Daily revenue (today)
            var dailyRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= today && 
                           o.CreatedAt < todayEnd)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var dailyOrderCount = await _context.Orders
                .CountAsync(o => o.Status == OrderStatus.Paid && 
                               o.CreatedAt >= today && 
                               o.CreatedAt < todayEnd);

            // Weekly revenue
            var weeklyRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= weekStart && 
                           o.CreatedAt < weekEnd)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var weeklyOrderCount = await _context.Orders
                .CountAsync(o => o.Status == OrderStatus.Paid && 
                               o.CreatedAt >= weekStart && 
                               o.CreatedAt < weekEnd);

            // Monthly revenue
            var monthlyRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= monthStart && 
                           o.CreatedAt < monthEnd)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var monthlyOrderCount = await _context.Orders
                .CountAsync(o => o.Status == OrderStatus.Paid && 
                               o.CreatedAt >= monthStart && 
                               o.CreatedAt < monthEnd);

            // Most ordered items (all time)
            var mostOrderedItems = await _context.OrderItems
                .Include(oi => oi.MenuItem)
                .Where(oi => oi.Order.Status == OrderStatus.Paid)
                .GroupBy(oi => new { oi.MenuItemId, oi.MenuItem.Name, oi.MenuItem.Category, oi.Price })
                .Select(g => new
                {
                    MenuItemId = g.Key.MenuItemId,
                    Name = g.Key.Name,
                    Category = g.Key.Category,
                    TotalQuantity = g.Sum(oi => oi.Quantity),
                    TotalRevenue = g.Sum(oi => oi.Price * oi.Quantity),
                    OrderCount = g.Select(oi => oi.OrderId).Distinct().Count()
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(10)
                .ToListAsync();

            // Revenue by payment method (today)
            var revenueByPaymentMethod = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= today && 
                           o.CreatedAt < todayEnd)
                .GroupBy(o => o.PaymentType)
                .Select(g => new
                {
                    PaymentMethod = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    Count = g.Count()
                })
                .ToListAsync();

            // Recent orders (today)
            var recentOrders = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Waiter)
                .Where(o => o.CreatedAt >= today && o.CreatedAt < todayEnd)
                .OrderByDescending(o => o.CreatedAt)
                .Take(10)
                .ToListAsync();

            // Orders by status (today)
            var ordersByStatus = await _context.Orders
                .Where(o => o.CreatedAt >= today && o.CreatedAt < todayEnd)
                .GroupBy(o => o.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            ViewBag.DailyRevenue = dailyRevenue;
            ViewBag.DailyOrderCount = dailyOrderCount;
            ViewBag.WeeklyRevenue = weeklyRevenue;
            ViewBag.WeeklyOrderCount = weeklyOrderCount;
            ViewBag.MonthlyRevenue = monthlyRevenue;
            ViewBag.MonthlyOrderCount = monthlyOrderCount;
            ViewBag.MostOrderedItems = mostOrderedItems;
            ViewBag.RevenueByPaymentMethod = revenueByPaymentMethod;
            ViewBag.RecentOrders = recentOrders;
            ViewBag.OrdersByStatus = ordersByStatus;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RevenueReport(DateTime? startDate = null, DateTime? endDate = null)
        {
            // Default to today if no dates provided
            var start = startDate ?? DateTime.UtcNow.Date;
            var end = (endDate ?? DateTime.UtcNow.Date).AddDays(1);

            // Revenue summary
            var totalRevenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= start && 
                           o.CreatedAt < end)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var totalOrders = await _context.Orders
                .CountAsync(o => o.Status == OrderStatus.Paid && 
                               o.CreatedAt >= start && 
                               o.CreatedAt < end);

            var averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            // Revenue by day
            var revenueByDay = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= start && 
                           o.CreatedAt < end)
                .GroupBy(o => o.CreatedAt.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToListAsync();

            // Revenue by payment method
            var revenueByPaymentRaw = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid && 
                           o.CreatedAt >= start && 
                           o.CreatedAt < end)
                .GroupBy(o => o.PaymentType)
                .Select(g => new
                {
                    PaymentMethod = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    Count = g.Count()
                })
                .ToListAsync();

            // Calculate percentages
            var revenueByPayment = revenueByPaymentRaw.Select(item => new
            {
                item.PaymentMethod,
                item.Revenue,
                item.Count,
                Percentage = totalRevenue > 0 ? (item.Revenue / totalRevenue) * 100 : 0m
            }).ToList();

            ViewBag.StartDate = start;
            ViewBag.EndDate = end.Date;
            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.TotalOrders = totalOrders;
            ViewBag.AverageOrderValue = averageOrderValue;
            ViewBag.RevenueByDay = revenueByDay;
            ViewBag.RevenueByPayment = revenueByPayment;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PopularItems(DateTime? startDate = null, DateTime? endDate = null, string category = null)
        {
            var start = startDate ?? DateTime.UtcNow.AddDays(-30).Date;
            var end = (endDate ?? DateTime.UtcNow.Date).AddDays(1);

            var query = _context.OrderItems
                .Include(oi => oi.MenuItem)
                .Where(oi => oi.Order.Status == OrderStatus.Paid &&
                           oi.Order.CreatedAt >= start &&
                           oi.Order.CreatedAt < end);

            // Filter by category if specified
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(oi => oi.MenuItem.Category == category);
            }

            var popularItems = await query
                .GroupBy(oi => new 
                { 
                    oi.MenuItemId, 
                    oi.MenuItem.Name, 
                    oi.MenuItem.Category, 
                    oi.MenuItem.Price,
                    oi.MenuItem.Description
                })
                .Select(g => new
                {
                    MenuItemId = g.Key.MenuItemId,
                    Name = g.Key.Name,
                    Category = g.Key.Category,
                    Price = g.Key.Price,
                    Description = g.Key.Description,
                    TotalQuantity = g.Sum(oi => oi.Quantity),
                    TotalRevenue = g.Sum(oi => oi.Price * oi.Quantity),
                    OrderCount = g.Select(oi => oi.OrderId).Distinct().Count(),
                    AverageQuantity = g.Average(oi => oi.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(50)
                .ToListAsync();

            // Get all categories for filter
            var categories = await _context.MenuItems
                .Select(m => m.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            ViewBag.StartDate = start;
            ViewBag.EndDate = end.Date;
            ViewBag.SelectedCategory = category;
            ViewBag.Categories = categories;
            ViewBag.PopularItems = popularItems;

            return View();
        }
    }
}

