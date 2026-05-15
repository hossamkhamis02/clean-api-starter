using CleanApi.API.Models;
using CleanApi.API.Services;
using CleanApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtService _jwtService;
    private readonly RefreshTokenService _refreshTokenService;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        JwtService jwtService,
        RefreshTokenService refreshTokenService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            return Unauthorized(ApiResponse<LoginResponse>.Fail("Invalid email or password."));

        var accessToken = _jwtService.GenerateToken(user);
        var refreshToken = await _refreshTokenService.GenerateRefreshTokenAsync(user);

        return Ok(ApiResponse<LoginResponse>.Ok(new LoginResponse(accessToken, refreshToken.TokenHash)));
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Refresh([FromBody] RefreshRequest request)
    {
        var refreshToken = await _refreshTokenService.GetValidTokenAsync(request.RefreshToken);
        if (refreshToken is null)
            return Unauthorized(ApiResponse<LoginResponse>.Fail("Invalid or expired refresh token."));

        var user = refreshToken.User;
        var newAccessToken = _jwtService.GenerateToken(user);
        var newRefreshToken = await _refreshTokenService.RotateRefreshTokenAsync(refreshToken);

        return Ok(ApiResponse<LoginResponse>.Ok(new LoginResponse(newAccessToken, newRefreshToken.TokenHash)));
    }
}

public sealed record LoginRequest(string Email, string Password);
public sealed record RefreshRequest(string RefreshToken);
public sealed record LoginResponse(string AccessToken, string RefreshToken);
