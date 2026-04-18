# Restaurant Management System

Restaurant Management System is an ASP.NET Core MVC web application for daily restaurant operations: order handling, kitchen workflow, reservation management, staff authentication, reporting, and payments.

## Tech Stack

- ASP.NET Core MVC (`net8.0`)
- Entity Framework Core + SQL Server
- Razor Views + Bootstrap 5
- Cookie authentication with role-based authorization
- Stripe integration (card payments + test mode)
- xUnit + EF Core InMemory for service tests

## Main Features

- Authentication and role-based access (`User`, `Kitchen`, `Administrator`)
- Waiter panel for creating and tracking orders
- Kitchen panel with status transitions and item-level readiness
- Reservation flow with table availability checks (AJAX)
- Admin area with reports:
  - dashboard KPIs
  - revenue reports by date/payment type
  - popular menu items report
- Cash and card payment flows
- Database seeding for core restaurant data

Note: demo bootstrap credentials/scripts are for local evaluation only and should be disabled in production environments.

## Architecture Overview

- `Controllers/` - MVC controllers for each business area
- `Areas/Admin/` - administrative dashboard and reports
- `Services/` - business logic (`OrderService`, `ReservationService`)
- `Data/` - `ApplicationDbContext` and seed sources
- `Models/` - entity models + view models
- `Views/` - Razor pages and partials
- `Scripts/` - SQL utility scripts

## Security and Validation

- CSRF protection on sensitive POST actions (`[ValidateAntiForgeryToken]`)
- Anti-forgery token usage in forms and AJAX requests
- Server-side validation in controllers and services
- Data annotation validation in view models/entities
- Parameterized EF Core queries (SQL injection-safe by design)
- Role-based endpoint access restrictions
- Custom error handling pages (`404`, `500`)

## Pagination and Filtering

- Kitchen orders support filter-aware pagination (`filter`, `page`, `pageSize`)
- Manager/admin reports support search/filter by date and category

## Database and Seeding

- `ApplicationDbContext` contains core sets and relationships
- `OnModelCreating` applies relationship configuration and seeds key data
- Additional SQL scripts are available in `Scripts/`

## Running Locally

Prerequisites:
- .NET 8 SDK
- SQL Server / LocalDB

1. Configure connection string in `appsettings.json`
2. Apply database migrations:
   - `dotnet ef database update`
3. Run the app:
   - `dotnet run`
4. Open:
   - `https://localhost:5001` (or the URL shown in console)

## Tests and Coverage

Test project: `RestaurantManagement.Tests`

- Run tests:
  - `dotnet test RestaurantManagement.sln`
- Run tests with coverage:
  - `dotnet test RestaurantManagement.Tests/RestaurantManagement.Tests.csproj --collect:"XPlat Code Coverage"`

Latest measured service-layer coverage from local run:
- Average service coverage: **91.78%**
- `OrderService`: **100%**
- `ReservationService`: **67.14%**

## CI

GitHub Actions workflow (`.github/workflows/ci.yml`) runs:
- restore
- build
- tests with coverage collection

## Deployment

Deployment preparation documents:
- `DEPLOYMENT.md` (step-by-step deployment checklist)
- `appsettings.Production.example.json` (production config template)

Public production URL:
- `TODO: add deployed URL before final submission`

## Submission Checklist

- [x] ASP.NET Core (.NET 6+)
- [x] 5+ controllers
- [x] 6+ entities
- [x] 15+ views
- [x] EF Core + SQL Server
- [x] MVC Areas
- [x] role-based authorization
- [x] CSRF/XSS-aware handling and validations
- [x] custom 404/500 pages
- [x] pagination + filtering
- [x] unit tests with >=65% service coverage
- [ ] public deployment URL added
