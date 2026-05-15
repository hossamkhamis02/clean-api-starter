## ADDED Requirements

### Requirement: EF Core initial migration is included
The repository SHALL contain an EF Core initial migration named `InitialCreate` or similar, covering all entities and relationships.

#### Scenario: Clone and migrate
- **WHEN** a developer clones the repo and runs `dotnet ef database update`
- **THEN** the database schema is created successfully without generating a new migration

### Requirement: Seed data populates on startup
The application SHALL seed 3 categories (e.g., Electronics, Clothing, Home & Garden) and 10 products distributed across those categories if the database tables are empty.

#### Scenario: Empty database startup
- **WHEN** the application starts against an empty database
- **THEN** after startup, the database contains exactly 3 categories and 10 products

### Requirement: Connection string supports environment override
The system SHALL read the SQL Server connection string from `appsettings.json` and allow override via the `ConnectionStrings__DefaultConnection` environment variable.

#### Scenario: Docker Compose override
- **WHEN** the API container starts with `ConnectionStrings__DefaultConnection` set to a Docker SQL Server instance
- **THEN** EF Core connects to the Docker SQL Server instead of localhost
