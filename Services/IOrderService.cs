using RestaurantManagement.Models;

namespace RestaurantManagement.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(Guid tableId, Guid waiterId, List<OrderItemRequest> items);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
    }

    public class OrderItemRequest
    {
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}


