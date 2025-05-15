# My Company Management Web App

## What's this about?
This is a web application I built using ASP.NET Core MVC while learning the framework. It's a company management system where you can handle employee data, departments, and user accounts.

![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core%20MVC-6.0-blue)
![C#](https://img.shields.io/badge/C%23-10.0-purple)
![Identity](https://img.shields.io/badge/Identity-6.0-green)
![AutoMapper](https://img.shields.io/badge/AutoMapper-12.0-orange)

## What I built

I created this project to practice ASP.NET Core MVC development. The app lets you:

- Log in and create user accounts with ASP.NET Core Identity
- Set up different user roles (admin, manager, regular user)
- Manage employees (add, view, edit, delete)
- Manage departments (add, view, edit, delete)
- Control who can access what based on their role

I tried to follow good coding practices by implementing proper architecture and some design patterns I learned about.

## Main features

- **User accounts**: Sign up, log in, log out
- **Role system**: Different permissions for different users
- **Admin controls**: Admins can assign roles to other users
- **Employee records**: Keep track of all employee info
- **Department management**: Organize employees by department
- **Proper architecture**: Used MVC pattern with clean separation
- **Data access patterns**: Implemented Repository and Unit of Work patterns
- **Query flexibility**: Used Specification pattern for better data retrieval
- **Clean mapping**: Used AutoMapper to convert between data models

## Tech stack

- ASP.NET Core MVC
- C#
- Entity Framework Core
- ASP.NET Core Identity
- AutoMapper
- Bootstrap
- SQL Server

## How to run it

### What you'll need

- Visual Studio 2019 or newer
- .NET 6.0 or later
- SQL Server (or SQL Server Express)

### Setup steps

1. Grab the code:
   ```
   git clone https://github.com/YourUsername/company-management-app.git
   ```

2. Open the solution in Visual Studio

3. Make sure NuGet packages are restored

4. Check the connection string in `appsettings.json` and update if needed

5. Create the database by running this in Package Manager Console:
   ```
   Update-Database
   ```

6. Hit F5 to build and run

## How it's organized

I structured the project with these main parts:

- **Models**: Database entities (Employee, Department)
- **Views**: All the UI templates
- **Controllers**: Handle requests and logic:
  - EmployeeController: For employee operations
  - DepartmentController: For department operations
  - AccountController: Handles logins and registration
  - RoleController: For managing user roles
- **Repositories**: Data access layer
- **UnitOfWork**: For managing database operations as a group
- **Specifications**: For building flexible queries
- **ViewModels**: Data objects specifically for views
- **Mapping**: AutoMapper configuration

## Design patterns I used

- **Repository Pattern**: Separates database code from business logic
- **Unit of Work**: Groups related database operations together
- **Specification Pattern**: Makes database queries more flexible
- **MVC Pattern**: Separates data, UI, and logic

## What I learned

Building this project taught me a lot about:

- ASP.NET Core MVC structure and workflow
- Setting up user accounts and security with Identity
- Creating and managing roles and permissions
- Working with databases through Entity Framework Core
- Building complete CRUD functionality
- Form validation and data handling
- Creating and using Razor views
- Working with related data (Employee-Department relationships)
- Implementing useful design patterns
- Using AutoMapper to simplify object conversions
- Writing maintainable and organized code
