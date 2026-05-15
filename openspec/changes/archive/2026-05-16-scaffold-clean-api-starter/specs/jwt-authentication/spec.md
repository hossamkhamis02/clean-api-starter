## ADDED Requirements

### Requirement: JWT tokens are issued on successful login
The system SHALL issue an access token (short-lived, e.g., 15 minutes) and a refresh token (long-lived, e.g., 7 days) when valid credentials are provided.

#### Scenario: Login returns tokens
- **WHEN** `POST /api/auth/login` is called with valid email and password
- **THEN** the response contains both `accessToken` and `refreshToken`

### Requirement: Refresh tokens are stored in the database
Refresh tokens SHALL be persisted in a `RefreshToken` table linked to `ApplicationUser`, including token hash, expiration date, and creation date.

#### Scenario: Token rotation
- **WHEN** `POST /api/auth/refresh` is called with a valid refresh token
- **THEN** a new access token and a new refresh token are issued, and the old refresh token is invalidated

### Requirement: Protected endpoints require valid JWT
Endpoints marked with `[Authorize]` SHALL reject requests missing or bearing an invalid/expired access token with `401 Unauthorized`.

#### Scenario: Unauthorized access
- **WHEN** `GET /api/products` is called without an `Authorization` header
- **THEN** the response status is `401 Unauthorized`
