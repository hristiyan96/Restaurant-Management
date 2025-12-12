using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Table
    {
        public Guid Id { get; set; }
        
        [Required]
        public int TableNumber { get; set; }
        
        [Required]
        public int Seats { get; set; }
        
        public bool IsOccupied { get; set; } = false;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}


