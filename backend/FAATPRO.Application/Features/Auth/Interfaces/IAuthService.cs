using FAATPRO.Application.Features.Auth.DTOs;

namespace FAATPRO.Application.Features.Auth.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);

    Task<LoginResponse> RefreshTokenAsync(
        RefreshTokenRequest request);

    Task LogoutAsync(
        LogoutRequest request);
}