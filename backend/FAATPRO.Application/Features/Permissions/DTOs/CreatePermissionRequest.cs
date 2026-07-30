namespace FAATPRO.Application.Features.Permissions.DTOs;

public class CreatePermissionRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}