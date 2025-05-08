# Company System MVC

A simple ASP.NET MVC application demonstrating user authentication and company data management implemented during my ASP.NET MVC learning journey.

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.0-blue)
![C#](https://img.shields.io/badge/C%23-8.0-purple)
![Identity](https://img.shields.io/badge/Identity-3.1-green)

## Overview

This project represents my learning experience with ASP.NET MVC. It's a company management system that implements:

User authentication and registration using ASP.NET Identity
Role-based authorization where administrators can assign roles to users
Complete CRUD (Create, Read, Update, Delete) operations for Employee management
Complete CRUD operations for Department management
Proper MVC architecture with separation of concerns

The application demonstrates fundamental web development concepts and database integration using Entity Framework.

## Features

- **User Authentication**: Complete login/logout functionality
- **User Registration**: New users can create accounts
- **Role-based Authorization**: Different access levels based on user roles
- **Admin Role Management**: Administrators can assign roles to users
- **Security**: Implementation of ASP.NET Identity for authentication and authorization
- **MVC Architecture**: Proper implementation of Model-View-Controller pattern
- **Employee Management**: Full CRUD operations (Create, Read, Update, Delete) for employee records
- **Department Management**: Full CRUD operations for department data

## Technologies Used

- ASP.NET MVC
- C#
- Entity Framework
- ASP.NET Identity
- Bootstrap
- SQL Server

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.8 or .NET Core 3.1+
- SQL Server (LocalDB or higher)

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/EslamAbdelwahid/company-system-mvc.git
   ```

2. Open the solution file in Visual Studio

3. Restore NuGet packages

4. Update database connection string in `Web.config` or `appsettings.json` if needed

5. Run the following commands in Package Manager Console to create database:
   ```
   Update-Database
   ```

6. Build and run the application

## Project Structure

The project follows the standard MVC architecture:

- **Models**: Data entities including Employee and Department models
- **Views**: User interface templates organized by controller
- **Controllers**: Handle HTTP requests and business logic for various modules
  - EmployeeController: Manages employee CRUD operations
  - DepartmentController: Manages department CRUD operations
  - AccountController: Handles user authentication
  - RoleController: Manages role assignments (Admin access only)
- **Identity**: User authentication and authorization implementation with role-based access control

## Learning Outcomes

Through this project, I've gained hands-on experience with:

- ASP.NET MVC architecture implementation
- User authentication and authorization with ASP.NET Identity
- Role-based access control and permissions
- Database operations using Entity Framework
- CRUD operations across multiple data entities
- Form validation and data handling
- Working with Razor views and partial views
- Managing application state
- Implementing relationship between models (Employee-Department)
