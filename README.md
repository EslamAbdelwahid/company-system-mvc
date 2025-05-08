# Company System MVC

A simple ASP.NET MVC application for managing company data with secure user authentication and role-based access control.

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.0-blue)
![C#](https://img.shields.io/badge/C%23-8.0-purple)
![Identity](https://img.shields.io/badge/Identity-3.1-green)

## Overview

This project is a basic company management system built with ASP.NET MVC architecture. It demonstrates fundamental web development concepts including:

- User registration and authentication
- Role-based authorization
- Token-based security
- MVC architectural pattern implementation
- Database integration

## Features

- **User Authentication**: Complete login/logout functionality
- **User Registration**: New users can create accounts
- **Role Management**: Different access levels for users
- **Security**: Implementation of ASP.NET Identity for authentication and authorization
- **Token Generation**: JWT token implementation for API security
- **Responsive UI**: Clean interface for company data management

## Technologies Used

- ASP.NET MVC
- C#
- Entity Framework
- ASP.NET Identity
- Bootstrap
- jQuery
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

```
CompanySystem/
├── Controllers/      # MVC Controllers
├── Models/           # Data models
├── Views/            # UI templates
├── Data/             # Database context and migrations
├── Services/         # Business logic layer
└── Areas/            # Feature areas including Identity
```

## Learning Resources

This project was developed as part of my ASP.NET MVC learning journey. It demonstrates the implementation of:

- MVC architectural pattern
- Authentication and authorization
- Database integration
- Dependency injection

## Future Improvements

- Add more advanced CRUD operations
- Implement file upload functionality
- Add reporting features
- Enhance UI/UX with modern JavaScript frameworks
- Implement comprehensive unit testing

## License

This project is available for review and educational purposes.

## Contact

Eslam Abdelwahid - [GitHub Profile](https://github.com/EslamAbdelwahid)

Project Link: [https://github.com/EslamAbdelwahid/company-system-mvc](https://github.com/EslamAbdelwahid/company-system-mvc)
