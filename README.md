# Company System MVC

A simple ASP.NET MVC application demonstrating user authentication and company data management implemented during my ASP.NET MVC learning journey.

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.0-blue)
![C#](https://img.shields.io/badge/C%23-8.0-purple)
![Identity](https://img.shields.io/badge/Identity-3.1-green)
![AutoMapper](https://img.shields.io/badge/AutoMapper-10.0-orange)

## Overview

This project represents my learning experience with ASP.NET MVC. It's a company management system that implements:

- User authentication and registration using ASP.NET Identity
- Role-based authorization where administrators can assign roles to users
- Complete CRUD (Create, Read, Update, Delete) operations for Employee management
- Complete CRUD operations for Department management
- Proper MVC architecture with separation of concerns
- Repository Pattern and Unit of Work for data access
- Specification Pattern for querying data
- AutoMapper for object-to-object mapping

The application demonstrates fundamental web development concepts, design patterns, and database integration using Entity Framework.

## Features

- **User Authentication**: Complete login/logout functionality
- **User Registration**: New users can create accounts
- **Role-based Authorization**: Different access levels based on user roles
- **Admin Role Management**: Administrators can assign roles to users
- **Security**: Implementation of ASP.NET Identity for authentication and authorization
- **MVC Architecture**: Proper implementation of Model-View-Controller pattern
- **Employee Management**: Full CRUD operations (Create, Read, Update, Delete) for employee records
- **Department Management**: Full CRUD operations for department data
- **Design Patterns**: Implementation of Repository, Unit of Work, and Specification patterns
- **Object Mapping**: Efficient mapping between models and DTOs using AutoMapper

## Technologies Used

- ASP.NET MVC
- C#
- Entity Framework
- ASP.NET Identity
- AutoMapper
- Bootstrap
- SQL Server

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.8 or .NET Core 3.1+
- SQL Server

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

The project follows the standard MVC architecture with additional layers for better separation of concerns:

- **Models**: Data entities including Employee and Department models
- **Views**: User interface templates organized by controller
- **Controllers**: Handle HTTP requests and business logic for various modules
  - EmployeeController: Manages employee CRUD operations
  - DepartmentController: Manages department CRUD operations
  - AccountController: Handles user authentication
  - RoleController: Manages role assignments (Admin access only)
- **Repositories**: Implementation of Repository Pattern for data access
- **UnitOfWork**: Implementation of Unit of Work Pattern for transaction management
- **Specifications**: Implementation of Specification Pattern for query encapsulation
- **DTOs/ViewModels**: Data Transfer Objects and View Models
- **AutoMapper Profiles**: Configuration for object-to-object mapping
- **Identity**: User authentication and authorization implementation with role-based access control

## Design Patterns Implemented

- **Repository Pattern**: Abstracts the data access layer, making the application more testable and maintainable
- **Unit of Work Pattern**: Manages transactions and ensures data consistency
- **Specification Pattern**: Encapsulates query logic, making it reusable and composable
- **MVC Pattern**: Separates the application into Model, View, and Controller components

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
- Applying design patterns (Repository, Unit of Work, Specification)
- Using AutoMapper for efficient object mapping
- Building maintainable and scalable applications
