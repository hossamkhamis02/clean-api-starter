## ADDED Requirements

### Requirement: Docker Compose runs API and SQL Server
The repository SHALL include a `docker-compose.yml` that launches the ASP.NET Core API and a SQL Server container with persistent volume.

#### Scenario: Docker startup
- **WHEN** `docker-compose up` is executed from the repository root
- **THEN** both the API and SQL Server containers start and the API is accessible on `http://localhost:5000`

### Requirement: README contains architecture diagram and run instructions
The `README.md` SHALL include a text-based architecture diagram, technology stack badges, prerequisites, and step-by-step run instructions.

#### Scenario: New developer onboarding
- **WHEN** a developer reads the README
- **THEN** they can clone, build, and run the project without additional guidance

### Requirement: Environment configuration excludes secrets
`appsettings.json` and `appsettings.Development.json` SHALL contain placeholder or non-secret values only. An `.env.example` file SHALL list all required environment variables.

#### Scenario: Secret safety
- **WHEN** the repository is pushed to a public GitHub repo
- **THEN** no JWT signing keys, passwords, or connection strings with credentials are exposed in committed files
