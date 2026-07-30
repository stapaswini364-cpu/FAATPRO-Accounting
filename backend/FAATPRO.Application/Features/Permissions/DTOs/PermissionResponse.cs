namespace FAATPRO.Application.Features.Permissions.DTOs;

public class PermissionResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}