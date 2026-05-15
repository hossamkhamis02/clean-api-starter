## ADDED Requirements

### Requirement: All unhandled exceptions return ProblemDetails
The middleware SHALL catch all unhandled exceptions and return an RFC 7807 `ProblemDetails` response with `type`, `title`, `status`, `detail`, and `instance` fields.

#### Scenario: Unexpected server error
- **WHEN** an unhandled exception occurs in any request pipeline stage
- **THEN** the response is `500 Internal Server Error` with a `ProblemDetails` JSON body

### Requirement: Validation failures map to ProblemDetails
FluentValidation `ValidationException` SHALL be mapped to a `400 Bad Request` ProblemDetails response containing field-level errors in the `errors` dictionary.

#### Scenario: Validation error response
- **WHEN** a request fails validation
- **THEN** the response status is `400 Bad Request` and the `errors` property contains `{ "PropertyName": [ "Error message" ] }`

### Requirement: Not-found responses use ProblemDetails
When a resource is not found (e.g., `GetProductByIdQuery` for missing ID), the system SHALL return `404 Not Found` with a ProblemDetails body.

#### Scenario: Missing product
- **WHEN** `GET /api/products/{nonexistent-id}` is called
- **THEN** the response status is `404 Not Found` with a `ProblemDetails` body describing the missing resource
