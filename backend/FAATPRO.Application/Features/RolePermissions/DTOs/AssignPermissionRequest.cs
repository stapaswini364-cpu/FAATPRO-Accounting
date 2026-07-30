namespace FAATPRO.Application.Features.RolePermissions.DTOs;

public class AssignPermissionRequest
{
    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }
}