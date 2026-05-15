## 1. Solution Scaffolding

- [x] 1.1 Create solution file `clean-api-starter.sln` at repository root
- [x] 1.2 Create `src/CleanApi.Domain` class library (target `net8.0`, nullable enabled)
- [x] 1.3 Create `src/CleanApi.Application` class library with project reference to Domain
- [x] 1.4 Create `src/CleanApi.Infrastructure` class library with references to Domain and Application
- [x] 1.5 Create `src/CleanApi.API` ASP.NET Core Web API project with references to all inner layers
- [x] 1.6 Create `tests/CleanApi.Application.Tests` xUnit project referencing Application
- [x] 1.7 Create `tests/CleanApi.Infrastructure.Tests` xUnit project referencing Infrastructure
- [x] 1.8 Add `.gitignore` (standard VisualStudio / .NET template)

## 2. Domain Layer

- [x] 2.1 Define `BaseEntity` abstract class with `Id`, `CreatedAt`, `UpdatedAt`, `IsDeleted`
- [x] 2.2 Define `ISoftDeletable` interface with `Delete()` method
- [x] 2.3 Create `Category` entity (`Id`, `Name`, `Description`)
- [x] 2.4 Create `Product` entity (`Id`, `Name`, `SKU`, `Price`, `CategoryId`, navigation to `Category`)
- [x] 2.5 Define `IRepository<T>` generic repository interface in Domain
- [x] 2.6 Define `IUnitOfWork` interface with `SaveChangesAsync()`

## 3. Application Layer

- [x] 3.1 Install MediatR, FluentValidation, and AutoMapper packages in Application project
- [x] 3.2 Create `Result<T>` and `Result` classes with success/failure states
- [x] 3.3 Create `PagedResult<T>` wrapper for paginated responses
- [x] 3.4 Create `CreateProductCommand`, handler, and `CreateProductDto`
- [x] 3.5 Create `UpdateProductCommand`, handler, and `UpdateProductDto`
- [x] 3.6 Create `DeleteProductCommand` and handler (soft delete)
- [x] 3.7 Create `GetProductByIdQuery` and handler
- [x] 3.8 Create `GetProductsQuery` and handler with pagination support
- [x] 3.9 Create `ValidationBehavior<TRequest, TResponse>` MediatR pipeline behavior
- [x] 3.10 Create `LoggingBehavior<TRequest, TResponse>` MediatR pipeline behavior
- [x] 3.11 Add FluentValidation validators for all commands
- [x] 3.12 Add `ApplicationServiceExtensions` with `AddApplication()` DI registration method

## 4. Infrastructure Layer

- [x] 4.1 Install EF Core 8, SQL Server provider, and Identity packages in Infrastructure project
- [x] 4.2 Create `ApplicationDbContext` inheriting from `IdentityDbContext<ApplicationUser>`
- [x] 4.3 Configure global query filter for soft deletes in `OnModelCreating`
- [x] 4.4 Override `SaveChangesAsync` to auto-populate `CreatedAt` and `UpdatedAt`
- [x] 4.5 Implement `EfRepository<T>` generic repository
- [x] 4.6 Implement `UnitOfWork` wrapping `ApplicationDbContext`
- [x] 4.7 Create `ApplicationUser` entity extending `IdentityUser` with navigation to refresh tokens
- [x] 4.8 Create `RefreshToken` entity with token hash, expiry, and user relationship
- [x] 4.9 Add `InfrastructureServiceExtensions` with `AddInfrastructure()` DI registration method
- [x] 4.10 Generate EF Core initial migration (`InitialCreate`) including all entities
- [x] 4.11 Create `DbContextSeed` class to seed 3 categories and 10 products on startup
- [x] 4.12 Ensure seeding runs automatically when database is empty

## 5. API Presentation Layer

- [x] 5.1 Install Swashbuckle, Scalar, Serilog, and JWT Bearer packages in API project
- [x] 5.2 Create `ApiResponse<T>` wrapper class for all controller responses
- [x] 5.3 Create `ProductsController` with endpoints: GET (paginated), GET by ID, POST, PUT, DELETE
- [x] 5.4 Create `AuthController` with `Login` and `RefreshToken` endpoints
- [x] 5.5 Implement `JwtService` for token generation and validation
- [x] 5.6 Implement `RefreshTokenService` for token rotation and storage
- [x] 5.7 Add global exception handling middleware returning RFC 7807 ProblemDetails
- [x] 5.8 Map `ValidationException` to `400 Bad Request` ProblemDetails
- [x] 5.9 Map `NotFoundException` (or Result failure) to `404 Not Found` ProblemDetails
- [x] 5.10 Configure Serilog with console and file sinks in `Program.cs`
- [x] 5.11 Configure Swagger and Scalar UI with JWT security scheme
- [x] 5.12 Add `Authorization` policy and `[Authorize]` attribute to protected endpoints
- [x] 5.13 Wire up `AddApplication()` and `AddInfrastructure()` in `Program.cs`

## 6. Project Tooling & Configuration

- [x] 6.1 Add `appsettings.json` with connection string placeholder and JWT settings
- [x] 6.2 Add `appsettings.Development.json` with local development overrides
- [x] 6.3 Add `.env.example` listing required environment variables
- [x] 6.4 Create `docker-compose.yml` with SQL Server and API services
- [x] 6.5 Create `Dockerfile` for the API project
- [x] 6.6 Write `README.md` with architecture diagram, badges, prerequisites, and run instructions
- [x] 6.7 Verify `dotnet build` succeeds from repository root
- [ ] 6.8 Verify `docker-compose up` launches both containers successfully
