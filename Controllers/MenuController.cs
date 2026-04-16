using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeedMenuItems()
        {
            try
            {
                var seedDate = DateTime.UtcNow;
                var menuItems = MenuSeedData.GetMenuItems(seedDate);

                // Get existing IDs to avoid duplicates
                var existingIds = await _context.MenuItems.Select(m => m.Id).ToListAsync();

                // Filter out items that already exist
                var newItems = menuItems.Where(m => !existingIds.Contains(m.Id)).ToList();

                if (newItems.Any())
                {
                    _context.MenuItems.AddRange(newItems);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = $"Добавени са {newItems.Count} нови артикула в менюто!" });
                }

                return Json(new { success = true, message = "Всички артикули вече съществуват." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}








