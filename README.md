# StockFlow

StockFlow is a Windows Forms inventory and sales management application built with C#,
.NET 8, Entity Framework Core, and SQL Server. It is designed for small retail or
warehouse workflows where staff need to manage products, suppliers, stock movement,
sales, users, and basic reporting from one desktop application.

## Features

- Dashboard with product counts, low-stock alerts, sales totals, supplier counts, and revenue summaries.
- Product management with category, supplier, price, quantity, search, and stock status views.
- Category and supplier management.
- Sales workflow with cart-style sale creation and automatic stock deduction.
- Stock adjustment for stock-in and stock-out operations.
- Stock ledger that records inventory movement from manual adjustments and sales.
- User management with role promotion, demotion, and deletion controls.
- Reports for revenue and top-selling products.
- Password hashing with BCrypt.
- SQL Server persistence through Entity Framework Core.

## Tech Stack

- C# / .NET 8
- Windows Forms
- Entity Framework Core 8
- SQL Server
- BCrypt.Net-Next

## Requirements

- Windows
- .NET 8 SDK
- SQL Server or SQL Server Express / LocalDB
- Visual Studio 2022, Rider, or another .NET-capable IDE

## Database Configuration

The database connection is currently configured in `Data/AppDbContext.cs`:

```csharp
Data Source=localhost\MSSQLSERVER01;Initial Catalog=stockFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True
```

Before running the app, make sure the SQL Server instance name matches your machine.
If your local instance is different, update the connection string in
`Data/AppDbContext.cs`.

On startup, the app calls `EnsureCreated()` and seeds the database if needed.

## Getting Started

Clone the repository:

```bash
git clone <repository-url>
cd StockFlow
```

Restore packages:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

You can also open `StockFlow.sln` in Visual Studio and run the project from there.

## Default Login

If no Super Admin user exists, the app creates one automatically:

```text
Username: superadmin
Password: superadmin
Role: SuperAdmin
```

Change this password after the first login in any real environment.

## Seed Data

When the product table is empty, `DataSeeder` adds starter data:

- 10 categories
- 5 suppliers
- 100 sample products with randomized prices and quantities

This gives the dashboard, product list, and low-stock views usable data immediately.

## Roles

StockFlow uses role-based access in the dashboard and management screens:

- `SuperAdmin`: full access, including revenue reports and user role management.
- `Admin`: management access for products, categories, suppliers, stock adjustment, reports, and users.
- `PermanentStaff`: operational access without management-only screens.
- `PartTimeStaff`: limited access.

## Project Structure

```text
Data/           EF Core DbContext and database seeding
Forms/          WinForms screens and designer files
Migrations/     EF Core migration history
Models/         Entity models
Repositories/   Generic repository abstraction
Services/       Business logic for auth, products, sales, categories, and suppliers
Utilities/      Shared UI/runtime helpers
Program.cs      Application startup, database initialization, and seed entry point
```

## Common Commands

Build:

```bash
dotnet build
```

Run:

```bash
dotnet run
```

Add a migration:

```bash
dotnet ef migrations add <MigrationName>
```

Apply migrations manually:

```bash
dotnet ef database update
```

## Notes

- The app targets `net8.0-windows`, so it is intended to run on Windows.
- The current startup path uses `EnsureCreated()`. If you rely fully on EF Core
  migrations, consider switching startup initialization to `Database.Migrate()`.
- Some UI text and labels are stored in WinForms designer files, so update both
  code-behind and designer-generated files carefully.
