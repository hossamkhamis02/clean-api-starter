<<<<<<< HEAD
# clean-api-starter
ASP.NET Core 8 Clean Architecture starter — CQRS, EF Core, JWT auth, MediatR, FluentValidation, Result pattern, and more. Production-quality boilerplate ready to build on.
=======
# Clean API Starter

A production-quality ASP.NET Core 8 Web API boilerplate using Clean Architecture, demonstrating enterprise-level .NET patterns.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=flat)](https://learn.microsoft.com/en-us/ef/core/)
[![MediatR](https://img.shields.io/badge/MediatR-14.1-512BD4?style=flat)](https://github.com/jbogard/MediatR)
[![FluentValidation](https://img.shields.io/badge/FluentValidation-12.1-512BD4?style=flat)](https://docs.fluentvalidation.net/)
[![Serilog](https://img.shields.io/badge/Serilog-8.0-512BD4?style=flat)](https://serilog.net/)

## Architecture

```
src/
├── CleanApi.Domain/           # Entities, Interfaces (zero dependencies)
├── CleanApi.Application/      # CQRS Handlers, DTOs, Validators, Behaviors
├── CleanApi.Infrastructure/   # EF Core, Repositories, Identity
└── CleanApi.API/              # Controllers, Middleware, JWT Auth, Swagger

         ┌──────────┐
         │   API    │  Presentation — thin controllers
         └────┬─────┘
    ┌─────────┼─────────┐
    │         │         │
┌───▼───┐ ┌──▼───┐ ┌───▼──────┐
│ Infra │ │ App  │ │  Domain  │  ← Innermost layer
└───────┘ └──────┘ └──────────┘
```

**Dependency direction**: API → Infrastructure → Application → Domain (innermost)

## Tech Stack

| Category       | Technology                                    |
|----------------|-----------------------------------------------|
| Framework      | ASP.NET Core 8 Web API                        |
| ORM            | Entity Framework Core 8 + SQL Server          |
| CQRS           | MediatR 14.1                                  |
| Validation     | FluentValidation 12.1 (pipeline behavior)     |
| Auth           | JWT Bearer + Refresh Tokens                   |
| Logging        | Serilog (Console + File)                      |
| API Docs       | Swagger + Scalar UI                           |
| Testing        | xUnit                                         |

## Patterns Implemented

- **Clean Architecture** — strict layer separation with dependency inversion
- **CQRS** — commands and queries separated via MediatR
- **Repository + Unit of Work** — abstracted persistence
- **Result Pattern** — `Result<T>` for expected failures, no exceptions for control flow
- **Pipeline Behaviors** — cross-cutting concerns via MediatR behaviors (Validation, Logging)
- **PagedResult<T>** — paginated list responses with metadata
- **ApiResponse<T>** — consistent API response envelope
- **Global Exception Handling** — RFC 7807 ProblemDetails middleware
- **Soft Delete** — all entities support soft delete via `IsDeleted` flag
- **Audit Fields** — `CreatedAt` / `UpdatedAt` auto-populated via `SaveChanges` override

## Demo Domain: Product Catalog

- **Product**: Id, Name, SKU, Price, CategoryId, CreatedAt, UpdatedAt, IsDeleted
- **Category**: Id, Name, Description
- Full CRUD via CQRS endpoints
- Seed data: 3 categories + 10 products

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for SQL Server)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (if running without Docker)

## Getting Started

### 1. Clone and restore

```bash
git clone <repository-url>
cd clean-api-starter
dotnet restore
```

### 2. Start SQL Server (Docker)

```bash
docker-compose up -d sqlserver
```

Or use the full stack:

```bash
docker-compose up
```

### 3. Run the API

```bash
dotnet run --project src/CleanApi.API
```

The API will be available at `https://localhost:5001`.

### 4. Access API Documentation

- **Swagger UI**: `https://localhost:5001/swagger`
- **Scalar UI**: `https://localhost:5001/scalar/v1`

### 5. Authenticate

Register a user and login to get a JWT token, then use it in the Swagger/Scalar UI to access protected endpoints.

## Configuration

| Environment Variable                 | Description                | Default                            |
|--------------------------------------|----------------------------|------------------------------------|
| `ConnectionStrings__DefaultConnection` | SQL Server connection    | See `appsettings.json`            |
| `Jwt__Key`                           | JWT signing key            | Development key (change in prod)   |
| `Jwt__Issuer`                        | JWT issuer                 | CleanApi                           |
| `Jwt__Audience`                      | JWT audience               | CleanApi                           |
| `Jwt__TokenExpiryMinutes`            | Access token expiry (min)  | 15                                 |

See `.env.example` for all environment variables.

## Running Tests

```bash
dotnet test
```

## License

MIT
>>>>>>> 84e39d4 (Initial commit: ASP.NET Core 8 Clean Architecture API starter)
