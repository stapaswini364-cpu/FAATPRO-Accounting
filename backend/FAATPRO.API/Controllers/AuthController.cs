using FAATPRO.Application.Features.Auth.DTOs;
using FAATPRO.Application.Features.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }


    /// <summary>
    /// User Login
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var response = await _authService.LoginAsync(request);


        return Ok(new
        {
            success = true,
            message = "Login successful",
            data = response
        });
    }


    /// <summary>
    /// Refresh JWT Token
    /// </summary>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var response = await _authService.RefreshTokenAsync(request);


        return Ok(new
        {
            success = true,
            message = "Token refreshed successfully",
            data = response
        });
    }


    /// <summary>
    /// Logout User
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout(
        [FromBody] LogoutRequest request)
    {
        await _authService.LogoutAsync(request);


        return Ok(new
        {
            success = true,
            message = "Logout successful"
        });
    }
}