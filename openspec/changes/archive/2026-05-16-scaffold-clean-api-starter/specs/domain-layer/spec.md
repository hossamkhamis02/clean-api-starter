## ADDED Requirements

### Requirement: Product entity exists with required fields
The system SHALL define a `Product` entity with the following fields: `Id` (Guid), `Name` (string, max 200), `SKU` (string, max 50, unique), `Price` (decimal), `CategoryId` (Guid), `CreatedAt` (DateTime), `UpdatedAt` (DateTime?), `IsDeleted` (bool).

#### Scenario: Product creation
- **WHEN** a new Product is instantiated with valid data
- **THEN** all fields are set and `IsDeleted` defaults to `false`

### Requirement: Category entity exists
The system SHALL define a `Category` entity with fields: `Id` (Guid), `Name` (string, max 100), `Description` (string, max 500).

#### Scenario: Category association
- **WHEN** a Product is assigned to a Category
- **THEN** the Product's `CategoryId` matches the Category's `Id`

### Requirement: Soft delete is supported on all entities
All entities SHALL implement a common interface (e.g., `ISoftDeletable`) exposing `IsDeleted` and a `Delete()` method that sets `IsDeleted` to `true`.

#### Scenario: Soft delete execution
- **WHEN** `Delete()` is called on an entity
- **THEN** `IsDeleted` becomes `true` and the entity remains in the database

### Requirement: Audit fields are automatically populated
The system SHALL automatically set `CreatedAt` on insert and `UpdatedAt` on update via a `SaveChanges` override or interceptor.

#### Scenario: Create audit
- **WHEN** a new entity is saved to the database
- **THEN** `CreatedAt` is set to the current UTC time

#### Scenario: Update audit
- **WHEN** an existing entity is modified and saved
- **THEN** `UpdatedAt` is set to the current UTC time
