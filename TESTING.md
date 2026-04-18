# Testing Guide

## Local test run

- `dotnet test RestaurantManagement.sln`

## Coverage run

- `dotnet test RestaurantManagement.Tests/RestaurantManagement.Tests.csproj --collect:"XPlat Code Coverage"`

## Current focus

- Service-layer business rules (`OrderService`, `ReservationService`)
- Regression scenarios around status transitions and reservation conflicts
