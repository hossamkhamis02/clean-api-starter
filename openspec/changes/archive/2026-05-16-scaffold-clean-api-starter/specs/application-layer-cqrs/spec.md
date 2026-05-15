## ADDED Requirements

### Requirement: Commands and queries are separated
The system SHALL use distinct types for commands (mutations) and queries (reads), each handled by dedicated MediatR handlers implementing `IRequestHandler<TRequest, TResponse>`.

#### Scenario: CreateProductCommand handler exists
- **WHEN** a `CreateProductCommand` is sent via MediatR
- **THEN** the `CreateProductCommandHandler` executes, persists the product, and returns the product ID

#### Scenario: GetProductsQuery handler exists
- **WHEN** a `GetProductsQuery` is sent via MediatR
- **THEN** the `GetProductsQueryHandler` returns a paginated list of products

### Requirement: DTOs are used for all inputs and outputs
Handlers SHALL accept and return DTOs, never raw entities. DTOs SHALL be defined in the Application layer.

#### Scenario: Command uses DTO
- **WHEN** `CreateProductCommand` is constructed
- **THEN** it contains a `CreateProductDto` instead of a `Product` entity

### Requirement: FluentValidation runs via pipeline behavior
Validation SHALL execute automatically before the handler via a `ValidationBehavior<TRequest, TResponse>` registered in the MediatR pipeline.

#### Scenario: Invalid command is rejected
- **WHEN** a `CreateProductCommand` with an empty `Name` is sent
- **THEN** the pipeline behavior raises a `ValidationException` before the handler executes

### Requirement: Logging behavior records request duration
A `LoggingBehavior<TRequest, TResponse>` SHALL log the request type, handler name, and execution duration for every MediatR request.

#### Scenario: Successful request is logged
- **WHEN** any command or query completes successfully
- **THEN** an informational log entry is written with the request type and elapsed milliseconds
