using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;

namespace RestaurantManagement.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private const int ReservationDurationHours = 2; // Standard reservation duration

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateReservationAsync(CreateReservationRequest request)
        {
            // Validate table availability
            if (!await IsTableAvailableAsync(request.TableId, request.ReservationDateTime))
            {
                throw new InvalidOperationException("Table is not available at the selected time.");
            }

            // Validate guest count
            var table = await _context.Tables.FindAsync(request.TableId);
            if (table == null)
            {
                throw new InvalidOperationException("Table not found.");
            }

            if (request.NumberOfGuests > table.Seats)
            {
                throw new InvalidOperationException($"Table can only accommodate {table.Seats} guests.");
            }

            if (request.NumberOfGuests < 1)
            {
                throw new InvalidOperationException("Number of guests must be at least 1.");
            }

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                TableId = request.TableId,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                ReservationDateTime = request.ReservationDateTime,
                NumberOfGuests = request.NumberOfGuests,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<List<Table>> GetAvailableTablesAsync(DateTime reservationDateTime, int numberOfGuests)
        {
            var allTables = await _context.Tables
                .Where(t => t.Seats >= numberOfGuests)
                .OrderBy(t => t.Seats)
                .ToListAsync();

            var availableTables = new List<Table>();

            foreach (var table in allTables)
            {
                if (await IsTableAvailableAsync(table.Id, reservationDateTime))
                {
                    availableTables.Add(table);
                }
            }

            return availableTables;
        }

        public async Task<bool> IsTableAvailableAsync(Guid tableId, DateTime reservationDateTime)
        {
            // Check if table exists and is not occupied
            var table = await _context.Tables.FindAsync(tableId);
            if (table == null || table.IsOccupied)
            {
                return false;
            }

            // Calculate reservation time window
            var reservationStart = reservationDateTime;
            var reservationEnd = reservationDateTime.AddHours(ReservationDurationHours);

            // Check for conflicting reservations
            var conflictingReservations = await _context.Reservations
                .Where(r => r.TableId == tableId)
                .Where(r => r.ReservationDateTime < reservationEnd && 
                           r.ReservationDateTime.AddHours(ReservationDurationHours) > reservationStart)
                .CountAsync();

            if (conflictingReservations > 0)
            {
                return false;
            }

            // Check for active orders at the same time
            var conflictingOrders = await _context.Orders
                .Where(o => o.TableId == tableId)
                .Where(o => o.Status != OrderStatus.Paid)
                .Where(o => o.CreatedAt < reservationEnd && 
                           o.CreatedAt.AddHours(ReservationDurationHours) > reservationStart)
                .CountAsync();

            return conflictingOrders == 0;
        }

        public async Task<Reservation?> GetReservationByIdAsync(Guid reservationId)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .FirstOrDefaultAsync(r => r.Id == reservationId);
        }

        public async Task<List<Reservation>> GetReservationsByDateAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await _context.Reservations
                .Include(r => r.Table)
                .Where(r => r.ReservationDateTime >= startOfDay && r.ReservationDateTime < endOfDay)
                .OrderBy(r => r.ReservationDateTime)
                .ToListAsync();
        }

        public async Task<bool> CancelReservationAsync(Guid reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return false;
            }

            // Only allow cancellation if reservation is in the future
            if (reservation.ReservationDateTime <= DateTime.UtcNow)
            {
                return false;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}





