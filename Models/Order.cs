using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public enum OrderStatus
    {
        Pending,
        Preparing,
        Ready,
        Served,
        Paid
    }

    public enum PaymentMethod
    {
        Cash,
        Card
    }

    public class Order
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid TableId { get; set; }
        
        public Guid? WaiterId { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        
        public PaymentMethod? PaymentType { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual Table Table { get; set; } = null!;
        public virtual User? Waiter { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}


