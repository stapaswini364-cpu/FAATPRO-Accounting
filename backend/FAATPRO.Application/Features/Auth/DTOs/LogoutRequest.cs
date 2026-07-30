using System.ComponentModel.DataAnnotations;

namespace FAATPRO.Application.Features.Auth.DTOs;

public class LogoutRequest
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}