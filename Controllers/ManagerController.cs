using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManagerController : Controller
    {
        // Backward-compatible redirects: manager routes now live in the Admin area.
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult RevenueReport(DateTime? startDate = null, DateTime? endDate = null)
        {
            return RedirectToAction("RevenueReport", "Dashboard", new { area = "Admin", startDate, endDate });
        }

        [HttpGet]
        public IActionResult PopularItems(DateTime? startDate = null, DateTime? endDate = null, string category = "")
        {
            return RedirectToAction("PopularItems", "Dashboard", new { area = "Admin", startDate, endDate, category });
        }
    }
}

