You are a senior .NET architect. Scaffold a production-quality ASP.NET Core 8 Web API 
boilerplate using Clean Architecture. This will be used as a GitHub portfolio project 
to demonstrate enterprise-level .NET skills.

## Project Name
clean-api-starter

## Solution Structure
src/
  CleanApi.Domain/          # Entities, ValueObjects, Domain Events, Interfaces
  CleanApi.Application/     # CQRS (MediatR), DTOs, Validators, Interfaces
  CleanApi.Infrastructure/  # EF Core, Repositories, External services
  CleanApi.API/             # Controllers, Middleware, DI registration
tests/
  CleanApi.Application.Tests/
  CleanApi.Infrastructure.Tests/

## Technical Requirements
- .NET 8 / ASP.NET Core 8
- MediatR (CQRS — Commands/Queries separated)
- Entity Framework Core 8 + SQL Server
- FluentValidation (pipeline behavior, not manual)
- JWT Authentication + Refresh Token (stored in DB)
- Global Exception Handling middleware (ProblemDetails RFC 7807 format)
- Serilog (console + file sink, structured logging)
- Swagger / Scalar UI with JWT support
- Result pattern (no raw exceptions crossing layer boundaries)

## Demo Domain: Product Catalog
Use a simple but realistic domain:
- Product (Id, Name, SKU, Price, CategoryId, CreatedAt, UpdatedAt, IsDeleted)
- Category (Id, Name, Description)
- Soft delete on all entities
- Audit fields (CreatedAt, UpdatedAt) via SaveChanges override

Implement full CRUD for Product using CQRS:
- CreateProductCommand / UpdateProductCommand / DeleteProductCommand
- GetProductByIdQuery / GetProductsQuery (with pagination: page, pageSize)

## Patterns to implement
- Repository pattern + Unit of Work
- MediatR pipeline behaviors: ValidationBehavior + LoggingBehavior
- PagedResult<T> wrapper for list responses
- ApiResponse<T> wrapper for all responses (success + error)
- Extension methods for DI registration per layer (AddApplication(), AddInfrastructure())

## Database
- SQL Server (connection string in appsettings, override via env var)
- EF Core Migrations (include initial migration)
- Seed data: 3 categories + 10 products

## Project files to include
- README.md with: project overview, architecture diagram (text-based), how to run, tech stack badges
- .gitignore (standard .NET)
- docker-compose.yml (API + SQL Server)
- appsettings.json + appsettings.Development.json (no secrets hardcoded)
- .env.example

## Code Quality
- Nullable reference types enabled
- No business logic in controllers (thin controllers)
- No direct DbContext usage outside Infrastructure layer
- XML comments on all public interfaces and DTOs

Start by creating the full solution structure, then implement layer by layer. 
After each layer, confirm before moving to the next.