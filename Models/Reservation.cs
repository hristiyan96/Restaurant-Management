using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid TableId { get; set; }
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        
        public string? CustomerPhone { get; set; }
        
        [Required]
        public DateTime ReservationDateTime { get; set; }
        
        public int NumberOfGuests { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual Table Table { get; set; } = null!;
    }
}


