## ADDED Requirements

### Requirement: Full CRUD for Product via CQRS
The system SHALL support creating, reading (by ID and paginated list), updating, and soft-deleting products through dedicated commands and queries.

#### Scenario: Create product
- **WHEN** `CreateProductCommand` is executed with valid data
- **THEN** a new product is persisted and its ID is returned

#### Scenario: Update product
- **WHEN** `UpdateProductCommand` is executed with an existing product ID
- **THEN** the product fields are updated and `UpdatedAt` is refreshed

#### Scenario: Delete product
- **WHEN** `DeleteProductCommand` is executed with an existing product ID
- **THEN** the product's `IsDeleted` flag is set to `true`

#### Scenario: Get product by ID
- **WHEN** `GetProductByIdQuery` is executed with an existing product ID
- **THEN** the full product details are returned

#### Scenario: List products with pagination
- **WHEN** `GetProductsQuery` is executed with `page=1` and `pageSize=10`
- **THEN** up to 10 non-deleted products are returned with pagination metadata
