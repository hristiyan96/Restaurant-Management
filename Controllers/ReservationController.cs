using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Models.ViewModels;
using RestaurantManagement.Services;

namespace RestaurantManagement.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ApplicationDbContext _context;

        public ReservationController(IReservationService reservationService, ApplicationDbContext context)
        {
            _reservationService = reservationService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Book()
        {
            var model = new ReservationViewModel
            {
                ReservationDateTime = DateTime.Now.AddDays(1).Date.AddHours(18)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Validate date/time is in the future
            if (model.ReservationDateTime <= DateTime.Now)
            {
                ModelState.AddModelError("ReservationDateTime", "Резервацията трябва да бъде в бъдещо време.");
                return View(model);
            }

            // Validate date is not too far in the future (e.g., max 3 months)
            if (model.ReservationDateTime > DateTime.Now.AddMonths(3))
            {
                ModelState.AddModelError("ReservationDateTime", "Резервацията може да бъде направена най-много 3 месеца напред.");
                return View(model);
            }

            // If table is selected, check availability and create reservation
            if (model.SelectedTableId.HasValue)
            {
                try
                {
                    var request = new CreateReservationRequest
                    {
                        TableId = model.SelectedTableId.Value,
                        CustomerName = model.CustomerName,
                        CustomerEmail = model.CustomerEmail,
                        CustomerPhone = model.CustomerPhone,
                        ReservationDateTime = model.ReservationDateTime,
                        NumberOfGuests = model.NumberOfGuests,
                        Notes = model.Notes
                    };

                    var reservationId = await _reservationService.CreateReservationAsync(request);
                    return RedirectToAction("Confirmation", new { id = reservationId });
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    // Reload available tables
                    await LoadAvailableTables(model);
                    return View(model);
                }
            }

            // If no table selected, show available tables
            await LoadAvailableTables(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckAvailability([FromBody] CheckAvailabilityRequest request)
        {
            try
            {
                var availableTables = await _reservationService.GetAvailableTablesAsync(
                    request.ReservationDateTime,
                    request.NumberOfGuests
                );

                return Json(new
                {
                    success = true,
                    tables = availableTables.Select(t => new
                    {
                        id = t.Id,
                        tableNumber = t.TableNumber,
                        seats = t.Seats
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(Guid id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        private async Task LoadAvailableTables(ReservationViewModel model)
        {
            try
            {
                var availableTables = await _reservationService.GetAvailableTablesAsync(
                    model.ReservationDateTime,
                    model.NumberOfGuests
                );

                ViewBag.AvailableTables = availableTables;
            }
            catch
            {
                ViewBag.AvailableTables = new List<Table>();
            }
        }
    }

    public class CheckAvailabilityRequest
    {
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfGuests { get; set; }
    }
}





