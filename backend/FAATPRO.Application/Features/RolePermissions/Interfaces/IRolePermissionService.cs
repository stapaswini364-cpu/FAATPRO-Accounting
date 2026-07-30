using FAATPRO.Application.Features.RolePermissions.DTOs;

namespace FAATPRO.Application.Features.RolePermissions.Interfaces;

public interface IRolePermissionService
{
    Task<RolePermissionResponse?> GetByRoleIdAsync(
        Guid roleId);


    Task<bool> AssignPermissionAsync(
        AssignPermissionRequest request);


    Task<bool> RemovePermissionAsync(
        Guid roleId,
        Guid permissionId);
}