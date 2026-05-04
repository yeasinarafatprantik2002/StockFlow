# StockFlow Inventory Management System

StockFlow is a modern, professional **Single-Form Application (SPA)** designed for high-performance inventory tracking and sales management. Built with C# and .NET WinForms, it features a premium, modern aesthetic optimized for full-screen displays.

## ✨ Key Features

- **Centralized Dashboard**: Real-time business analytics including revenue tracking and critical low-stock alerts.
- **Advanced POS Terminal**: A high-speed sales interface designed for rapid checkout with automated stock deduction.
- **Enterprise Management**:
  - **Products**: Detailed inventory tracking with category and supplier associations.
  - **Staff Management**: Role-based access control (SuperAdmin, Admin, PermanentStaff, PartTimeStaff) with promotion/demotion workflows.
  - **Stock Ledger**: Comprehensive movement history tracking for all inventory transactions.
- **Modern UI/UX**:
  - Seamless SPA navigation with child-form viewport.
  - Optimized data grids with real-time conditional formatting.
  - Premium, padded input fields and professional color palettes.

## 🚀 Getting Started

### Prerequisites
- .NET SDK (6.0 or higher recommended)
- Visual Studio 2022 or VS Code

### Installation
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```bash
   cd StockFlow
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## 🛠️ Technology Stack
- **Languages**: C#
- **Framework**: .NET WinForms
- **Data Persistence**: Entity Framework Core with SQLite
- **Architecture**: Service-Repository Pattern

## 🛡️ Security & Roles
StockFlow implements a robust security model:
- **SuperAdmin**: Full system control including staff deletion and demotion.
- **Admin**: Can manage inventory and onboard part-time staff.
- **PermanentStaff**: Can manage sales and view inventory status.
- **PartTimeStaff**: Restricted access to sales operations.

## 📄 License
This project is licensed under the MIT License.
