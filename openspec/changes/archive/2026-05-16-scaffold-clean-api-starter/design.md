## Context

This is a greenfield repository (`clean-api-starter`) intended to become a GitHub portfolio project showcasing enterprise .NET skills. The goal is to demonstrate Clean Architecture, CQRS, modern authentication, and production-grade patterns in a single, runnable solution.

Constraints:
- .NET 8 SDK target
- SQL Server for persistence (via Docker Compose for local dev)
- No existing code, migrations, or infrastructure
- Must be immediately clone-and-run ready

## Goals / Non-Goals

**Goals:**
- Establish a four-layer Clean Architecture solution with clear dependency direction
- Implement CQRS using MediatR with separated commands and queries
- Provide JWT authentication with refresh token rotation
- Add global exception handling returning RFC 7807 ProblemDetails
- Implement a complete Product Catalog CRUD as the demo domain
- Ensure thin controllers, no business logic in presentation layer
- Include Docker Compose, README, and environment configuration
- Enable nullable reference types for compile-time safety

**Non-Goals:**
- Multi-tenancy or role-based access control (RBAC) beyond basic JWT claims
- Real-time features (SignalR, WebSockets)
- Caching layer (Redis)
- CI/CD pipelines or cloud deployment manifests
- Unit tests for API layer (only Application and Infrastructure tests)
- Frontend application or mobile client

## Decisions

**Decision 1: Clean Architecture over N-Tier**
- *Rationale*: Clean Architecture enforces dependency direction (Domain → Application → Infrastructure → API), making the project immediately recognizable to reviewers. N-Tier is more common in legacy .NET Framework projects.
- *Alternative considered*: Vertical Slice Architecture — rejected because Clean Architecture is more universally understood in portfolio reviews.

**Decision 2: MediatR + CQRS over direct service classes**
- *Rationale*: MediatR decouples request handling from controllers and enables pipeline behaviors (validation, logging) without cross-cutting code in handlers.
- *Alternative considered*: Classic service/repository with DI — rejected because it does not demonstrate modern .NET patterns.

**Decision 3: Repository pattern + Unit of Work over direct DbContext access**
- *Rationale*: Abstracts persistence details from Application layer, satisfying Clean Architecture constraints. EF Core’s `DbContext` already implements UoW, but explicit interfaces make testing and swapping easier.
- *Alternative considered*: Direct `DbContext` injection into handlers — rejected because it leaks infrastructure concerns into Application layer.

**Decision 4: Result<T> pattern over exceptions for expected failures**
- *Rationale*: Expected failures (validation, not-found) are returned as values rather than thrown, keeping exception handling for truly exceptional cases only.
- *Alternative considered*: Exceptions for everything — rejected because it complicates middleware and obscures control flow.

**Decision 5: Serilog over built-in ILogger configuration**
- *Rationale*: Structured logging with file sink is a production standard and demonstrates awareness of observability.
- *Alternative considered*: Default `Microsoft.Extensions.Logging` with simple console — rejected because it lacks structured output and file persistence.

**Decision 6: Scalar UI over Swagger UI**
- *Rationale*: Scalar provides a modern, fast API documentation experience with built-in JWT support, aligning with current industry trends.
- *Alternative considered*: Swagger UI (Swashbuckle) — acceptable fallback, but Scalar is the modern default.

## Risks / Trade-offs

- **[Risk] Over-engineering for a demo domain** → *Mitigation*: Keep the Product Catalog domain simple (two entities). Patterns are the showcase, not the domain complexity.
- **[Risk] JWT refresh token storage in SQL Server adds schema complexity** → *Mitigation*: Use a simple `RefreshToken` entity linked to `ApplicationUser`. Clean up expired tokens via a background job later (out of scope for initial scaffolding).
- **[Risk] MediatR pipeline behaviors may confuse junior reviewers** → *Mitigation*: Add XML comments and a brief architecture diagram in README.
- **[Risk] Nullable reference types require strict discipline** → *Mitigation*: Enable `<Nullable>enable</Nullable>` in all project files from day one; compiler will enforce.
