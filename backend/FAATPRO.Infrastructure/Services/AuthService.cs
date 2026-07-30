using FAATPRO.Application.Common.Interfaces;
using FAATPRO.Application.Features.Auth.DTOs;
using FAATPRO.Application.Features.Auth.Interfaces;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        ApplicationDbContext context,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        Console.WriteLine();
        Console.WriteLine("========== LOGIN DEBUG ==========");

        Console.WriteLine($"Email Entered : {request.Email}");
        Console.WriteLine($"Password      : {request.Password}");

        var user = await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user == null)
        {
            Console.WriteLine("RESULT : USER NOT FOUND");
            Console.WriteLine("=================================");
            throw new Exception("Invalid email or password.");
        }

        Console.WriteLine($"User Found    : YES");
        Console.WriteLine($"DB Email      : {user.Email}");
        Console.WriteLine($"User Id       : {user.Id}");
        Console.WriteLine($"Is Active     : {user.IsActive}");
        Console.WriteLine($"Password Hash : {user.PasswordHash}");

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash);

        Console.WriteLine($"Password Match: {isPasswordValid}");

        if (user.UserRoles != null)
        {
            Console.WriteLine($"Role Count    : {user.UserRoles.Count}");
            foreach (var role in user.UserRoles)
            {
                Console.WriteLine($"Role          : {role.Role.Name}");
            }
        }

        Console.WriteLine("=================================");

        if (!user.IsActive)
            throw new Exception("User account is inactive.");

        if (!isPasswordValid)
            throw new Exception("Invalid email or password.");

        var roles = user.UserRoles
            .Select(x => x.Role.Name)
            .ToList();

        var accessToken =
            _jwtTokenGenerator.GenerateToken(user, roles);

        var refreshToken =
            Guid.NewGuid().ToString("N");

        _context.RefreshTokens.Add(new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = refreshToken,
            ExpiryDate = DateTime.UtcNow.AddDays(
                request.RememberMe ? 30 : 7),
            IsRevoked = false
        });

        await _context.SaveChangesAsync();

        Console.WriteLine("Login Successful");
        Console.WriteLine();

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),

            User = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Roles = roles
            }
        };
    }

    public async Task<LoginResponse> RefreshTokenAsync(
        RefreshTokenRequest request)
    {
        var refreshToken = await _context.RefreshTokens
            .Include(x => x.User)
            .ThenInclude(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

        if (refreshToken == null)
            throw new Exception("Invalid refresh token.");

        if (refreshToken.IsRevoked)
            throw new Exception("Refresh token revoked.");

        if (refreshToken.ExpiryDate < DateTime.UtcNow)
            throw new Exception("Refresh token expired.");

        var user = refreshToken.User;

        var roles = user.UserRoles
            .Select(x => x.Role.Name)
            .ToList();

        var newAccessToken =
            _jwtTokenGenerator.GenerateToken(user, roles);

        return new LoginResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = refreshToken.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),

            User = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Roles = roles
            }
        };
    }

    public async Task LogoutAsync(
        LogoutRequest request)
    {
        var refreshToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

        if (refreshToken == null)
            return;

        refreshToken.IsRevoked = true;

        await _context.SaveChangesAsync();
    }
}