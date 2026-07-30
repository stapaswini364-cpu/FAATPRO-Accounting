using FAATPRO.Application.Features.Permissions.DTOs;

namespace FAATPRO.Application.Features.Permissions.Interfaces;

public interface IPermissionService
{
    Task<List<PermissionResponse>> GetAllAsync();

    Task<PermissionResponse?> GetByIdAsync(Guid id);

    Task<PermissionResponse> CreateAsync(
        CreatePermissionRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreatePermissionRequest request);

    Task<bool> DeleteAsync(Guid id);
}