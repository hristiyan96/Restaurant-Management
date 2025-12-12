using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid OrderId { get; set; }
        
        [Required]
        public Guid MenuItemId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        public string? Notes { get; set; }
        
        public bool IsReady { get; set; } = false;
        
        // Navigation properties
        public virtual Order Order { get; set; } = null!;
        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}


