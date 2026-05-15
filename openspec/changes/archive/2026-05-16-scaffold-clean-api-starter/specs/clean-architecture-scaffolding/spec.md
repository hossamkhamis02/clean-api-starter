## ADDED Requirements

### Requirement: Solution structure follows Clean Architecture
The solution SHALL contain five projects arranged in concentric dependency layers: Domain (innermost, zero dependencies), Application (depends on Domain), Infrastructure (depends on Application and Domain), API (depends on all inner layers), plus test projects for Application and Infrastructure.

#### Scenario: Project references are correct
- **WHEN** the solution is opened in Visual Studio or built with `dotnet build`
- **THEN** Domain has no project references, Application references only Domain, Infrastructure references Application and Domain, and API references all three

#### Scenario: Dependency direction is enforced
- **WHEN** a developer attempts to add a reference from Domain to Application or Infrastructure
- **THEN** the build fails or the architectural boundary is visibly violated

### Requirement: Layer registration via extension methods
Each layer SHALL expose a single extension method (`AddDomain()`, `AddApplication()`, `AddInfrastructure()`) that registers all services, repositories, and configurations for that layer.

#### Scenario: API layer registration
- **WHEN** the API project calls `builder.Services.AddApplication()` and `builder.Services.AddInfrastructure()`
- **THEN** all handlers, validators, repositories, and DbContext are registered in the DI container
