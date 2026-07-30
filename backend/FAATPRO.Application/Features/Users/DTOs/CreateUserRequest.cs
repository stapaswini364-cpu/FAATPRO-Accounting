namespace FAATPRO.Application.Features.Users.DTOs;

public class CreateUserRequest
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public List<Guid> RoleIds { get; set; } = new();
}