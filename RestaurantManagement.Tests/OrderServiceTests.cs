using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task CreateOrderAsync_ShouldCreateOrderItems_AndMarkTableOccupied()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 201, Seats = 4, IsOccupied = false };
        var waiter = new User
        {
            Id = Guid.NewGuid(),
            Email = "waiter@example.com",
            FullName = "Waiter One",
            PasswordHash = "hash",
            Role = UserRole.User
        };
        var soup = new MenuItem { Id = Guid.NewGuid(), Name = "Soup", Category = "Food", Price = 5.50m };
        var salad = new MenuItem { Id = Guid.NewGuid(), Name = "Salad", Category = "Food", Price = 7.00m };

        context.Tables.Add(table);
        context.Users.Add(waiter);
        context.MenuItems.AddRange(soup, salad);
        await context.SaveChangesAsync();

        var service = new OrderService(context);
        var orderId = await service.CreateOrderAsync(
            table.Id,
            waiter.Id,
            new List<OrderItemRequest>
            {
                new() { MenuItemId = soup.Id, Quantity = 2 },
                new() { MenuItemId = salad.Id, Quantity = 1 }
            });

        var created = await context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        Assert.NotNull(created);
        Assert.Equal(OrderStatus.Pending, created.Status);
        Assert.Equal(18.00m, created.TotalAmount);
        Assert.Equal(2, created.OrderItems.Count);
        Assert.True((await context.Tables.FindAsync(table.Id))!.IsOccupied);
    }

    [Fact]
    public async Task CreateOrderAsync_ShouldIgnoreUnknownMenuItems()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 202, Seats = 4 };
        var waiter = new User
        {
            Id = Guid.NewGuid(),
            Email = "waiter2@example.com",
            FullName = "Waiter Two",
            PasswordHash = "hash",
            Role = UserRole.User
        };

        context.Tables.Add(table);
        context.Users.Add(waiter);
        await context.SaveChangesAsync();

        var service = new OrderService(context);
        var orderId = await service.CreateOrderAsync(
            table.Id,
            waiter.Id,
            new List<OrderItemRequest> { new() { MenuItemId = Guid.NewGuid(), Quantity = 2 } });

        var created = await context.Orders.Include(o => o.OrderItems).FirstAsync(o => o.Id == orderId);

        Assert.Empty(created.OrderItems);
        Assert.Equal(0m, created.TotalAmount);
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_ShouldUpdateStatus_AndTimestamp()
    {
        using var context = CreateContext();
        var order = new Order
        {
            Id = Guid.NewGuid(),
            TableId = Guid.NewGuid(),
            Status = OrderStatus.Pending,
            UpdatedAt = DateTime.UtcNow.AddMinutes(-10)
        };
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        var previousUpdatedAt = order.UpdatedAt;
        var service = new OrderService(context);

        await service.UpdateOrderStatusAsync(order.Id, OrderStatus.Ready);

        var updated = await context.Orders.FindAsync(order.Id);
        Assert.NotNull(updated);
        Assert.Equal(OrderStatus.Ready, updated.Status);
        Assert.True(updated.UpdatedAt >= previousUpdatedAt);
    }

    [Fact]
    public async Task GetOrderByIdAsync_ShouldReturnOrderWithRelatedEntities()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 203, Seats = 6 };
        var waiter = new User
        {
            Id = Guid.NewGuid(),
            Email = "waiter3@example.com",
            FullName = "Waiter Three",
            PasswordHash = "hash",
            Role = UserRole.User
        };
        var menuItem = new MenuItem { Id = Guid.NewGuid(), Name = "Pizza", Category = "Food", Price = 12m };
        var order = new Order
        {
            Id = Guid.NewGuid(),
            TableId = table.Id,
            WaiterId = waiter.Id,
            Status = OrderStatus.Preparing,
            TotalAmount = 24m
        };
        var orderItem = new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            MenuItemId = menuItem.Id,
            Quantity = 2,
            Price = menuItem.Price
        };

        context.Tables.Add(table);
        context.Users.Add(waiter);
        context.MenuItems.Add(menuItem);
        context.Orders.Add(order);
        context.OrderItems.Add(orderItem);
        await context.SaveChangesAsync();

        var service = new OrderService(context);
        var fetched = await service.GetOrderByIdAsync(order.Id);

        Assert.NotNull(fetched);
        Assert.NotNull(fetched.Table);
        Assert.NotNull(fetched.Waiter);
        Assert.Single(fetched.OrderItems);
        Assert.Equal("Pizza", fetched.OrderItems.First().MenuItem.Name);
    }

    [Fact]
    public async Task GetOrderByIdAsync_ShouldReturnNull_WhenOrderMissing()
    {
        using var context = CreateContext();
        var service = new OrderService(context);

        var fetched = await service.GetOrderByIdAsync(Guid.NewGuid());

        Assert.Null(fetched);
    }

    [Fact]
    public async Task CreateOrderAsync_ShouldPersistProvidedWaiterId()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 204, Seats = 2 };
        var waiter = new User { Id = Guid.NewGuid(), Email = "persist@example.com", FullName = "Persist Waiter", PasswordHash = "hash", Role = UserRole.User };
        var item = new MenuItem { Id = Guid.NewGuid(), Name = "Tea", Category = "Drinks", Price = 2m };
        context.Tables.Add(table);
        context.Users.Add(waiter);
        context.MenuItems.Add(item);
        await context.SaveChangesAsync();

        var service = new OrderService(context);
        var orderId = await service.CreateOrderAsync(table.Id, waiter.Id, new List<OrderItemRequest> { new() { MenuItemId = item.Id, Quantity = 1 } });

        var created = await context.Orders.FindAsync(orderId);
        Assert.Equal(waiter.Id, created?.WaiterId);
    }

    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"order-tests-{Guid.NewGuid()}")
            .Options;

        return new ApplicationDbContext(options);
    }
}
