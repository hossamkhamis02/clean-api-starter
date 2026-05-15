## Why

We need a production-quality ASP.NET Core 8 Web API boilerplate using Clean Architecture to serve as a GitHub portfolio project demonstrating enterprise-level .NET skills. The current repository is empty and requires a complete, well-structured foundation that showcases modern patterns, testability, and maintainability.

## What Changes

- Scaffold a full Clean Architecture solution with four layers (Domain, Application, Infrastructure, API) plus test projects
- Implement CQRS with MediatR, separating commands and queries with dedicated handlers
- Add Entity Framework Core 8 with SQL Server provider, initial migration, and seed data
- Configure JWT authentication with refresh token support stored in the database
- Implement global exception handling middleware returning RFC 7807 ProblemDetails
- Add structured logging with Serilog (console + file sinks)
- Integrate Swagger / Scalar UI with JWT bearer token support
- Implement the Result pattern to avoid raw exceptions crossing layer boundaries
- Add MediatR pipeline behaviors for validation (FluentValidation) and logging
- Implement a demo Product Catalog domain with full CRUD operations
- Add repository pattern, Unit of Work, pagination, and API response wrappers
- Include project tooling: README, .gitignore, docker-compose, appsettings, .env.example
- Enable nullable reference types across all projects

## Capabilities

### New Capabilities
- `clean-architecture-scaffolding`: Solution structure, project references, and DI registration per layer
- `domain-layer`: Entities, value objects, domain events, and repository interfaces
- `application-layer-cqrs`: Commands, queries, handlers, DTOs, validators, and MediatR behaviors
- `infrastructure-layer`: EF Core, repositories, external service implementations, and data persistence
- `api-presentation-layer`: Controllers, middleware, JWT configuration, and API documentation
- `jwt-authentication`: JWT token issuance, validation, refresh token rotation, and secure storage
- `global-exception-handling`: RFC 7807 ProblemDetails middleware and custom exception mapping
- `product-catalog-domain`: Product and Category entities with soft delete and audit fields
- `database-migrations-seeding`: EF Core initial migration and seed data (3 categories + 10 products)
- `project-tooling-docker`: Docker Compose setup, README, .gitignore, and environment configuration

### Modified Capabilities
<!-- No existing capabilities modified — this is a greenfield project -->

## Impact

- Entire repository — new solution structure and all source files
- No external dependencies or APIs affected (new project)
- SQL Server required for local development (provided via Docker Compose)
- .NET 8 SDK required for build and run
