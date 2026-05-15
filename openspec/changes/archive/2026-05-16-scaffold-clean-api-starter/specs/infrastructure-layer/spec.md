## ADDED Requirements

### Requirement: DbContext implements soft delete filtering
The `ApplicationDbContext` SHALL globally filter out soft-deleted entities (`IsDeleted == true`) from all queries unless explicitly disabled.

#### Scenario: Query excludes deleted products
- **WHEN** a query requests all products
- **THEN** products where `IsDeleted` is `true` are excluded from results

### Requirement: Repositories abstract DbContext access
The Infrastructure layer SHALL implement generic and specific repositories (e.g., `IProductRepository`, `IUnitOfWork`) that encapsulate all database operations.

#### Scenario: Repository usage in handler
- **WHEN** an application handler calls `await _productRepository.AddAsync(product)`
- **THEN** the product is added to the DbContext and saved via `UnitOfWork.SaveChangesAsync()`

### Requirement: Initial migration covers all entities
An EF Core initial migration SHALL be created that includes `Product`, `Category`, `ApplicationUser`, and `RefreshToken` tables with correct relationships and indexes.

#### Scenario: Migration applies cleanly
- **WHEN** `dotnet ef database update` is executed
- **THEN** all tables are created without errors

### Requirement: Seed data is applied on startup
The system SHALL seed 3 categories and 10 products into the database on first run if the tables are empty.

#### Scenario: First run seeding
- **WHEN** the application starts with an empty database
- **THEN** 3 categories and 10 products are inserted
