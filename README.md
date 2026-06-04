# FizzBuzz Application

A modern ASP.NET Core REST API implementation of the classic FizzBuzz problem, built with .NET 10 and featuring Swagger/OpenAPI documentation.

## Project Overview

This project provides a web API that processes a list of input values and returns FizzBuzz results. It demonstrates best practices for building RESTful APIs using ASP.NET Core, including:

- Dependency injection patterns
- Service-oriented architecture
- Controller-based API endpoints
- Swagger/OpenAPI documentation
- Comprehensive input validation

## Features

- **REST API Endpoint**: Process multiple FizzBuzz values in a single request
- **Input Validation**: Handles invalid inputs gracefully
- **Swagger Documentation**: Interactive API documentation via Swagger UI
- **Dependency Injection**: Leverages ASP.NET Core's built-in DI container
- **Type Safety**: Strongly-typed request/response models

## Project Structure

```
FizzBuzz/
├── Controllers/
│   └── FizzBuzzController.cs      # API endpoint definition
├── Services/
│   └── FizzBuzzService.cs         # Core FizzBuzz logic
├── IServices/
│   └── IFizzBuzzService.cs        # Service interface
├── Entity/
│   └── FizzBuzzResponse.cs        # Response model
├── Program.cs                      # Application entry point
└── FizzBuzz.csproj                 # Project file

FizzBuzzTest/
└── (Unit tests for the service)
```

## Technology Stack

- **.NET**: 10
- **Framework**: ASP.NET Core
- **Documentation**: Swagger/OpenAPI
- **Architecture**: Dependency Injection, Repository Pattern

## How It Works

### FizzBuzz Logic

The application processes each input value according to these rules:

- If divisible by both 3 and 5: Output "FizzBuzz"
- If divisible by 3: Output "Fizz"
- If divisible by 5: Output "Buzz"
- If divisible by neither: Output "Checked: {value} By 3, {value} By 5"
- If invalid input: Output "Invalid Input"

### Response Model

Each result contains:

```csharp
{
  "input": "string",    // The original input value
  "output": "string"    // The FizzBuzz result
}
```

## API Usage

### Endpoint

```
POST /api/fizzbuzz
```

### Request

Content-Type: `application/json`

```json
["1", "3", "5", "15", "invalid"]
```

### Response

```json
[
  {
    "input": "1",
    "output": "Checked: 1 By 3, 1 By 5"
  },
  {
    "input": "3",
    "output": "Fizz"
  },
  {
    "input": "5",
    "output": "Buzz"
  },
  {
    "input": "15",
    "output": "FizzBuzz"
  },
  {
    "input": "invalid",
    "output": "Invalid Input"
  }
]
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio Community 2026 or Visual Studio Code

### Build

```powershell
dotnet build
```

### Run

```powershell
dotnet run
```

The application will start and be accessible at `https://localhost:5001` (or as configured).

### Access Swagger UI

Once running, navigate to:

```
https://localhost:5001/swagger/index.html
```

You can test the API directly from the Swagger UI.

## Testing

Run the unit tests using:

```powershell
dotnet test
```

## Architecture Highlights

### Dependency Injection

The `FizzBuzzService` is registered in `Program.cs` using:

```csharp
builder.Services.AddScoped<IFizzBuzzService, FizzBuzzService>();
```

This ensures proper lifecycle management and testability.

### Service Layer

The `IFizzBuzzService` interface abstracts the business logic, allowing for easy testing and implementation swapping.

### Input Validation

The controller validates that:
- The input list is not null
- The input list is not empty

## Development

### Code Style

- Follows C# coding conventions
- Uses meaningful variable names
- Includes proper null checking
- Implements proper error handling

### Future Enhancements

- Add unit tests for edge cases
- Implement caching for performance optimization
- Add batch processing capabilities
- Extend with additional FizzBuzz variants

## Repository

Source code: [GitHub - FizzBuzzApplication](https://github.com/tkazee/FizzBuzzApplication)

