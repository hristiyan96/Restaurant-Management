using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.Tests;

public class ReservationServiceTests
{
    [Fact]
    public async Task CreateReservationAsync_ShouldCreateReservation_WhenRequestIsValid()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 100, Seats = 4 };
        context.Tables.Add(table);
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var request = new CreateReservationRequest
        {
            TableId = table.Id,
            CustomerName = "Test User",
            CustomerEmail = "test@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(4),
            NumberOfGuests = 2
        };

        var reservationId = await service.CreateReservationAsync(request);
        var created = await context.Reservations.FindAsync(reservationId);

        Assert.NotNull(created);
        Assert.Equal(request.TableId, created.TableId);
        Assert.Equal(1, await context.Reservations.CountAsync());
    }

    [Fact]
    public async Task CreateReservationAsync_ShouldThrow_WhenTableDoesNotExist()
    {
        using var context = CreateContext();
        var service = new ReservationService(context);

        var request = new CreateReservationRequest
        {
            TableId = Guid.NewGuid(),
            CustomerName = "No Table",
            CustomerEmail = "no-table@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(3),
            NumberOfGuests = 2
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateReservationAsync(request));
    }

    [Fact]
    public async Task CreateReservationAsync_ShouldThrow_WhenGuestCountExceedsSeats()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 101, Seats = 2 };
        context.Tables.Add(table);
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var request = new CreateReservationRequest
        {
            TableId = table.Id,
            CustomerName = "Too Many",
            CustomerEmail = "many@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(5),
            NumberOfGuests = 5
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateReservationAsync(request));
    }

    [Fact]
    public async Task IsTableAvailableAsync_ShouldReturnFalse_WhenReservationConflicts()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 102, Seats = 4 };
        context.Tables.Add(table);
        context.Reservations.Add(new Reservation
        {
            Id = Guid.NewGuid(),
            TableId = table.Id,
            CustomerName = "Existing",
            CustomerEmail = "existing@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(2),
            NumberOfGuests = 2
        });
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var available = await service.IsTableAvailableAsync(table.Id, DateTime.UtcNow.AddHours(3));

        Assert.False(available);
    }

    [Fact]
    public async Task IsTableAvailableAsync_ShouldReturnFalse_WhenActiveOrderConflicts()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 103, Seats = 4 };
        context.Tables.Add(table);
        context.Orders.Add(new Order
        {
            Id = Guid.NewGuid(),
            TableId = table.Id,
            Status = OrderStatus.Preparing,
            CreatedAt = DateTime.UtcNow.AddHours(1)
        });
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var available = await service.IsTableAvailableAsync(table.Id, DateTime.UtcNow.AddHours(2));

        Assert.False(available);
    }

    [Fact]
    public async Task CancelReservationAsync_ShouldReturnTrue_AndDeleteFutureReservation()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 104, Seats = 4 };
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            TableId = table.Id,
            CustomerName = "Cancelable",
            CustomerEmail = "cancel@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(6),
            NumberOfGuests = 2
        };
        context.Tables.Add(table);
        context.Reservations.Add(reservation);
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var result = await service.CancelReservationAsync(reservation.Id);

        Assert.True(result);
        Assert.Null(await context.Reservations.FindAsync(reservation.Id));
    }

    [Fact]
    public async Task CancelReservationAsync_ShouldReturnFalse_ForPastReservation()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 105, Seats = 4 };
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            TableId = table.Id,
            CustomerName = "Past",
            CustomerEmail = "past@example.com",
            ReservationDateTime = DateTime.UtcNow.AddHours(-2),
            NumberOfGuests = 2
        };
        context.Tables.Add(table);
        context.Reservations.Add(reservation);
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var result = await service.CancelReservationAsync(reservation.Id);

        Assert.False(result);
        Assert.NotNull(await context.Reservations.FindAsync(reservation.Id));
    }

    [Fact]
    public async Task GetReservationsByDateAsync_ShouldReturnOnlyReservationsForRequestedDate()
    {
        using var context = CreateContext();
        var table = new Table { Id = Guid.NewGuid(), TableNumber = 106, Seats = 4 };
        context.Tables.Add(table);

        var requestedDate = DateTime.UtcNow.Date.AddDays(1);
        context.Reservations.AddRange(
            new Reservation
            {
                Id = Guid.NewGuid(),
                TableId = table.Id,
                CustomerName = "Match",
                CustomerEmail = "match@example.com",
                ReservationDateTime = requestedDate.AddHours(18),
                NumberOfGuests = 2
            },
            new Reservation
            {
                Id = Guid.NewGuid(),
                TableId = table.Id,
                CustomerName = "No Match",
                CustomerEmail = "nomatch@example.com",
                ReservationDateTime = requestedDate.AddDays(1).AddHours(18),
                NumberOfGuests = 2
            });
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var reservations = await service.GetReservationsByDateAsync(requestedDate);

        Assert.Single(reservations);
        Assert.Equal("Match", reservations[0].CustomerName);
    }

    [Fact]
    public async Task GetReservationByIdAsync_ShouldReturnNull_WhenMissing()
    {
        using var context = CreateContext();
        var service = new ReservationService(context);

        var reservation = await service.GetReservationByIdAsync(Guid.NewGuid());

        Assert.Null(reservation);
    }

    [Fact]
    public async Task GetAvailableTablesAsync_ShouldRespectMinimumSeatCount()
    {
        using var context = CreateContext();
        context.Tables.AddRange(
            new Table { Id = Guid.NewGuid(), TableNumber = 201, Seats = 2 },
            new Table { Id = Guid.NewGuid(), TableNumber = 202, Seats = 6 });
        await context.SaveChangesAsync();

        var service = new ReservationService(context);
        var available = await service.GetAvailableTablesAsync(DateTime.UtcNow.AddHours(6), 4);

        Assert.Single(available);
        Assert.Equal(6, available[0].Seats);
    }

    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"reservation-tests-{Guid.NewGuid()}")
            .Options;

        return new ApplicationDbContext(options);
    }
}
