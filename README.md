# Test Summary

I started the test at **11:18** and ended at **16:04**.

## Tools and Technologies Used:
- **Docker** for running **MSSQL** with the following credentials:
  - **User**: SA
  - **Password**: Password123

## Libraries and Frameworks:
- **MediatR**
- **Optional**
- **FluentValidation**
- **EntityFrameworkCore**
- **IoC (Inversion of Control)**
- **DependencyInjection**

## Architecture:
- Implemented **Clean Architecture**.
- Used **CQRS** (Command Query Responsibility Segregation) pattern.

# Completion

## Server-Side:
- [x] Users can upload a CSV file containing the specified fields.
- [x] The application processes the CSV file on the backend and saves the data to an **MS SQL** database.

## Client-Side:
- [x] Users can filter and sort the data by any column using JavaScript.
- [x] The table supports inline editing for any row, with an option to delete records from the database.

## Additional Features:
- [x] Implemented basic **data validation** and **error handling**.
