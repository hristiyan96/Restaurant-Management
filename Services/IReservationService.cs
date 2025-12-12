using RestaurantManagement.Models;

namespace RestaurantManagement.Services
{
    public interface IReservationService
    {
        Task<Guid> CreateReservationAsync(CreateReservationRequest request);
        Task<List<Table>> GetAvailableTablesAsync(DateTime reservationDateTime, int numberOfGuests);
        Task<bool> IsTableAvailableAsync(Guid tableId, DateTime reservationDateTime);
        Task<Reservation?> GetReservationByIdAsync(Guid reservationId);
        Task<List<Reservation>> GetReservationsByDateAsync(DateTime date);
        Task<bool> CancelReservationAsync(Guid reservationId);
    }

    public class CreateReservationRequest
    {
        public Guid TableId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string? Notes { get; set; }
    }
}





