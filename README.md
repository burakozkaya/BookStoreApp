# BookStoreApp

## Description

This project is a comprehensive solution that includes various features such as a custom exception handling middleware for an ASP.NET Core application, a Unit of Work pattern implementation for managing database operations, and more. The middleware catches any unhandled exceptions that occur in subsequent middleware or in the application, logs them to the database, and allows the application to continue running. The Unit of Work pattern is used to group database operations into a single transaction, ensuring data integrity.

## Getting Started

### Dependencies

* AutoMapper 12.0.1
* AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1
* Microsoft.EntityFrameworkCore 6.0.25
* Microsoft.EntityFrameworkCore.Design 6.0.25
* Microsoft.EntityFrameworkCore.SqlServer 6.0.25

### Installing

* Clone the repository
* Navigate to the project directory
* Run `dotnet restore`

### Configuration

* Open `appsettings.json` file
* Update the `ConnectionStrings` section with your database connection details
* If necessary, modify other settings according to your requirements

### Executing program

* Run `dotnet run` from the project directory

## Help

If you encounter any problems or issues, please check the error logs in the database. The custom exception handling middleware logs all unhandled exceptions there. If you need further assistance, feel free to open an issue on this repository.
