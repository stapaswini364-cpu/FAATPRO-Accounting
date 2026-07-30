namespace FAATPRO.Application.Features.RolePermissions.DTOs;

public class RolePermissionResponse
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;


    public List<string> Permissions { get; set; }
        = new();
}