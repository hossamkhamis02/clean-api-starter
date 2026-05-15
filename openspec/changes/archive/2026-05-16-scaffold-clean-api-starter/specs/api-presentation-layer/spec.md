## ADDED Requirements

### Requirement: Controllers are thin and delegate to MediatR
Controllers SHALL only construct commands/queries, send them via `IMediator`, and return `ApiResponse<T>` or `ActionResult`. No business logic SHALL exist in controllers.

#### Scenario: Create product endpoint
- **WHEN** `POST /api/products` is called with a valid request body
- **THEN** the controller sends a `CreateProductCommand` and returns `201 Created` with the product ID

### Requirement: ApiResponse<T> wraps all responses
All API responses SHALL be wrapped in a consistent `ApiResponse<T>` envelope containing `Success`, `Data`, `Message`, and `Errors` fields.

#### Scenario: Successful response format
- **WHEN** a request succeeds
- **THEN** the response body contains `{ "success": true, "data": { ... }, "message": null, "errors": null }`

#### Scenario: Error response format
- **WHEN** a request fails due to validation
- **THEN** the response body contains `{ "success": false, "data": null, "message": "...", "errors": [ ... ] }`

### Requirement: PagedResult<T> wraps paginated list responses
List endpoints returning multiple items SHALL use `PagedResult<T>` with `Items`, `Page`, `PageSize`, `TotalCount`, and `TotalPages`.

#### Scenario: Paginated product list
- **WHEN** `GET /api/products?page=2&pageSize=5` is called
- **THEN** the response contains exactly 5 items and metadata indicating total pages

### Requirement: Swagger and Scalar UI are configured with JWT support
The API SHALL expose Swagger JSON and Scalar UI endpoints. Both SHALL allow entering a JWT bearer token for authorized endpoints.

#### Scenario: Authenticated request from UI
- **WHEN** a user enters a JWT token in the Scalar UI authorization field
- **THEN** subsequent test requests include the `Authorization: Bearer <token>` header
