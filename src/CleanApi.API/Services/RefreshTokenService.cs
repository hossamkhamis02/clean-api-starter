using CleanApi.Infrastructure.Data;
using CleanApi.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanApi.API.Services;

/// <summary>
/// Service for managing refresh token generation, validation, and rotation.
/// </summary>
public sealed class RefreshTokenService
{
    private readonly ApplicationDbContext _context;

    public RefreshTokenService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken> GenerateRefreshTokenAsync(ApplicationUser user)
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            TokenHash = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id
        };

        _context.RefreshTokens.Add(token);
        await _context.SaveChangesAsync();

        return token;
    }

    public async Task<RefreshToken?> GetValidTokenAsync(string tokenHash)
    {
        return await _context.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt =>
                rt.TokenHash == tokenHash &&
                !rt.IsRevoked &&
                rt.ExpiresAt > DateTime.UtcNow);
    }

    public async Task<RefreshToken> RotateRefreshTokenAsync(RefreshToken oldToken)
    {
        oldToken.IsRevoked = true;

        var newToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            TokenHash = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            CreatedAt = DateTime.UtcNow,
            UserId = oldToken.UserId
        };

        _context.RefreshTokens.Update(oldToken);
        _context.RefreshTokens.Add(newToken);
        await _context.SaveChangesAsync();

        return newToken;
    }
}
