using FAATPRO.Application.Features.Roles.DTOs;

namespace FAATPRO.Application.Features.Roles.Interfaces;

public interface IRoleService
{
    Task<List<RoleResponse>> GetAllAsync();

    Task<RoleResponse?> GetByIdAsync(Guid id);

    Task<RoleResponse> CreateAsync(
        CreateRoleRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateRoleRequest request);

    Task<bool> DeleteAsync(Guid id);
}