using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Services;
using System.Security.Claims;
using Stripe;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Waiter,Manager")]
    public class WaiterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;

        public WaiterController(ApplicationDbContext context, IOrderService orderService, IConfiguration configuration)
        {
            _context = context;
            _orderService = orderService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var waiterId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            
            var activeOrders = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.WaiterId == waiterId && o.Status != OrderStatus.Paid)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            var tables = await _context.Tables.OrderBy(t => t.TableNumber).ToListAsync();
            var menuItems = await _context.MenuItems
                .Where(m => m.Available)
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToListAsync();

            ViewBag.ActiveOrders = activeOrders;
            ViewBag.Tables = tables;
            ViewBag.MenuItems = menuItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var waiterId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
                var orderId = await _orderService.CreateOrderAsync(request.TableId, waiterId, request.Items);
                
                return Json(new { success = true, orderId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, status);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Payment(Guid orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null || order.Status != OrderStatus.Served)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Order = order;
            var publishableKey = _configuration["Stripe:PublishableKey"];
            var testMode = _configuration.GetValue<bool>("Stripe:TestMode", false);
            ViewBag.TestMode = testMode;
            
            // Check if Stripe keys are configured (not placeholder values)
            if (testMode || string.IsNullOrEmpty(publishableKey) || 
                publishableKey.Contains("your_publishable_key") || 
                publishableKey.Contains("your_key_here"))
            {
                if (testMode)
                {
                    // In test mode, we'll use a mock key
                    ViewBag.StripePublishableKey = "pk_test_MOCK_KEY_FOR_TESTING";
                    ViewBag.StripeConfigured = true;
                }
                else
                {
                    ViewBag.StripePublishableKey = null;
                    ViewBag.StripeConfigured = false;
                }
            }
            else
            {
                ViewBag.StripePublishableKey = publishableKey;
                ViewBag.StripeConfigured = true;
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessCashPayment([FromBody] PaymentRequest request)
        {
            try
            {
                var order = await _context.Orders
                    .Include(o => o.Table)
                    .FirstOrDefaultAsync(o => o.Id == request.OrderId);

                if (order == null || order.Status != OrderStatus.Served)
                {
                    return Json(new { success = false, message = "Поръчката не е налична!" });
                }

                order.Status = OrderStatus.Paid;
                order.PaymentType = Models.PaymentMethod.Cash;
                order.UpdatedAt = DateTime.UtcNow;

                if (order.Table != null)
                {
                    order.Table.IsOccupied = false;
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Плащането в брой е успешно!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentIntent(Guid orderId)
        {
            try
            {
                var order = await _context.Orders
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null || order.Status != OrderStatus.Served)
                {
                    return Json(new { success = false, message = "Поръчката не е налична!" });
                }

                var testMode = _configuration.GetValue<bool>("Stripe:TestMode", false);
                
                // Test mode - simulate Stripe without real keys
                if (testMode)
                {
                    // Generate a mock payment intent ID for testing
                    var mockPaymentIntentId = $"pi_test_{Guid.NewGuid().ToString("N").Substring(0, 24)}";
                    var mockClientSecret = $"{mockPaymentIntentId}_secret_{Guid.NewGuid().ToString("N").Substring(0, 24)}";
                    
                    // Store in a simple way for confirmation (in production, use cache/session)
                    // For test mode, we'll just check the prefix
                    
                    return Json(new { 
                        success = true, 
                        clientSecret = mockClientSecret,
                        paymentIntentId = mockPaymentIntentId,
                        orderId = orderId,
                        amount = order.TotalAmount,
                        testMode = true
                    });
                }

                var secretKey = _configuration["Stripe:SecretKey"];
                
                if (string.IsNullOrEmpty(secretKey) || secretKey.Contains("your_secret_key"))
                {
                    return Json(new { 
                        success = false, 
                        message = "Stripe API ключът не е конфигуриран! Моля добавете валиден Stripe Secret Key в appsettings.json. Вижте STRIPE_SETUP.md за инструкции." 
                    });
                }

                StripeConfiguration.ApiKey = secretKey;

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(order.TotalAmount * 100), // Convert to cents
                    Currency = "bgn",
                    Metadata = new Dictionary<string, string>
                    {
                        { "orderId", orderId.ToString() }
                    }
                };

                var service = new PaymentIntentService();
                var paymentIntent = await service.CreateAsync(options);

                return Json(new { 
                    success = true, 
                    clientSecret = paymentIntent.ClientSecret,
                    orderId = orderId,
                    amount = order.TotalAmount
                });
            }
            catch (Stripe.StripeException ex)
            {
                return Json(new { 
                    success = false, 
                    message = $"Stripe грешка: {ex.Message}. Моля проверете вашите Stripe API ключове в appsettings.json" 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Грешка: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCardPayment([FromBody] CardPaymentRequest request)
        {
            try
            {
                var testMode = _configuration.GetValue<bool>("Stripe:TestMode", false);
                Order? order = null;
                
                // Test mode - simulate successful payment
                if (testMode && (request.PaymentIntentId.StartsWith("pi_test_") || request.PaymentIntentId.Contains("_test_")))
                {
                    order = await _context.Orders
                        .Include(o => o.Table)
                        .FirstOrDefaultAsync(o => o.Id == request.OrderId);

                    if (order == null || order.Status != OrderStatus.Served)
                    {
                        return Json(new { success = false, message = "Поръчката не е налична!" });
                    }

                    order.Status = OrderStatus.Paid;
                    order.PaymentType = Models.PaymentMethod.Card;
                    order.UpdatedAt = DateTime.UtcNow;

                    if (order.Table != null)
                    {
                        order.Table.IsOccupied = false;
                    }

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Плащането с карта е успешно! (Test Mode)" });
                }

                StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

                var service = new PaymentIntentService();
                var paymentIntent = await service.GetAsync(request.PaymentIntentId);

                if (paymentIntent.Status != "succeeded")
                {
                    return Json(new { success = false, message = "Плащането не беше успешно!" });
                }

                order = await _context.Orders
                    .Include(o => o.Table)
                    .FirstOrDefaultAsync(o => o.Id == request.OrderId);

                if (order == null || order.Status != OrderStatus.Served)
                {
                    return Json(new { success = false, message = "Поръчката не е налична!" });
                }

                order.Status = OrderStatus.Paid;
                order.PaymentType = Models.PaymentMethod.Card;
                order.UpdatedAt = DateTime.UtcNow;

                if (order.Table != null)
                {
                    order.Table.IsOccupied = false;
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Плащането с карта е успешно!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }

    public class CreateOrderRequest
    {
        public Guid TableId { get; set; }
        public List<OrderItemRequest> Items { get; set; } = new();
    }

    public class PaymentRequest
    {
        public Guid OrderId { get; set; }
    }

    public class CardPaymentRequest
    {
        public Guid OrderId { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}


