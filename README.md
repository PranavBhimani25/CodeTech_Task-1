# E-Commerce Website

An ASP.NET Core MVC based e-commerce application that allows users to browse products, add items to a shopping cart, and complete purchases securely. This README provides instructions for setup, configuration, and deployment.

---

## Table of Contents

1. [Project Overview](#project-overview)
2. [Technologies Used](#technologies-used)
3. [Prerequisites](#prerequisites)
4. [Installation](#installation)
5. [Configuration](#configuration)
6. [Database Setup](#database-setup)
7. [Running the Application](#running-the-application)
8. [Features](#features)
9. [Project Structure](#project-structure)
10. [Contributing](#contributing)
11. [License](#license)
12. [Contact](#contact)

---

## Project Overview

This e-commerce website is built with ASP.NET Core MVC and Entity Framework Core. It supports product listings, user authentication, shopping cart functionality, order management, and admin dashboards for inventory control.

Key functionalities:

* User registration and login (ASP.NET Identity)
* Product catalog with categories and search
* Shopping cart and checkout process
* Order history and invoice generation
* Admin area for managing products, categories, and orders

---

## Technologies Used

* **Framework**: ASP.NET Core MVC 6.0
* **ORM**: Entity Framework Core
* **Database**: SQL Server (LocalDB or full SQL Server)
* **Authentication**: ASP.NET Core Identity
* **Front-end**: Razor Views, Bootstrap 5
* **Dependency Injection**: Built-in ASP.NET Core DI

---

## Prerequisites

Before you begin, ensure you have the following installed on your development machine:

* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* [SQL Server](https://www.microsoft.com/sql-server/) or LocalDB
* [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community or higher) with ASP.NET and web development workload, or Visual Studio Code

---

## Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/ecommerce-aspnetcore-mvc.git
   cd ecommerce-aspnetcore-mvc
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

3. **Build the solution**

   ```bash
   dotnet build
   ```

---

## Configuration

1. **appsettings.json**

   * Update the `DefaultConnection` string under `ConnectionStrings` to point to your SQL Server instance:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

2. **User Secrets (optional for sensitive data)**

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Your_Production_Connection_String"
   ```

---

## Database Setup

1. **Apply Entity Framework Core migrations**

   ```bash
   dotnet ef database update
   ```

2. **(Optional) Seed initial data**

   * The project includes a data seeding routine. Modify `Data/DbInitializer.cs` to customize initial products, categories, and admin user.

---

## Running the Application

1. **Run via CLI**

   ```bash
   dotnet run --project ECommerce.Web
   ```

2. **Run via Visual Studio**

   * Open `ECommerce.sln`
   * Set `ECommerce.Web` as startup project
   * Press F5 to debug or Ctrl+F5 to run without debugging

Your application should now be accessible at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

---

## Features

* **Authentication & Authorization**

  * Register, login, and role-based access (User, Admin)
* **Product Management**

  * List, search, filter by category
* **Shopping Cart**

  * Add, remove items, update quantities
* **Checkout & Orders**

  * Checkout workflow, order confirmation, order history
* **Admin Dashboard**

  * CRUD operations for products, categories, orders

---

## Project Structure

```
ECommerce.sln
├── ECommerce.Web         # ASP.NET Core MVC project
├── ECommerce.Data        # EF Core DbContext and migrations
├── ECommerce.Core        # Domain models and interfaces
├── ECommerce.Services    # Business logic and services
└── README.md             # This file
```

---

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

For questions or support, please open an issue in the repository or contact maintainer:

* **Name**: Your Name
* **Email**: [pranavbhimani04@gmail.com](mailto:pranavbhimani04@gmail.com)
* **GitHub**: [PranavBhimani25](https://github.com/PranavBhimani25)
