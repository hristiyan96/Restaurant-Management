# Deployment Guide

This project is deployment-ready for ASP.NET Core hosting targets (Azure App Service, IIS, or Linux container hosts).

## 1) Production Configuration

Copy `appsettings.Production.example.json` to `appsettings.Production.json` and set real values:

- `ConnectionStrings:DefaultConnection`
- `Stripe:PublishableKey`
- `Stripe:SecretKey`

Do not commit real secrets.

Recommended: store secrets in platform environment variables / secret manager.

## 2) Database Migration in Production

Before first startup, apply migrations against production DB:

- `dotnet ef database update --configuration Release`

Or execute migration in CI/CD release stage.

## 3) Build and Publish

Local publish command:

- `dotnet publish RestaurantManagement.csproj -c Release -o ./publish`
- `dotnet test RestaurantManagement.sln -c Release`

Deploy the `publish` folder to your host.

## 4) Hosting Options

## Azure App Service (recommended)

1. Create SQL Database and App Service
2. Set connection string in App Service configuration
3. Set Stripe keys in App Service configuration
4. Deploy from GitHub repository or published artifacts

Required App Service configuration keys:
- `ConnectionStrings__DefaultConnection`
- `Stripe__PublishableKey`
- `Stripe__SecretKey`
- `ASPNETCORE_ENVIRONMENT=Production`

## IIS

1. Install ASP.NET Core Hosting Bundle
2. Create site/app pool
3. Point site to published output folder
4. Configure environment variables and permissions

## 5) Verification Checklist

- Application starts without exception
- Home page responds within acceptable time under normal load
- Login/register work
- Admin area access works only for `Administrator`
- Waiter/Kitchen flows work
- Reservation and payment flows work
- Error pages (`/Error/404`, `/Error/ServerError`) render correctly
- HTTPS is enabled

## 6) Final Submission

After deployment, update `README.md`:

- replace `TODO: add deployed URL before final submission` with real public URL
- optionally add screenshots/video link

## 7) Rollback Note

Keep the latest successful publish artifacts so you can roll back quickly if a production issue appears after release.
