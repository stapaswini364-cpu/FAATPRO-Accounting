using FAATPRO.Application.Features.AccountSubGroups.DTOs;

namespace FAATPRO.Application.Features.AccountSubGroups.Interfaces;

public interface IAccountSubGroupService
{
    Task<List<AccountSubGroupResponse>> GetAllAsync();

    Task<AccountSubGroupResponse?> GetByIdAsync(Guid id);

    Task<AccountSubGroupResponse> CreateAsync(
        CreateAccountSubGroupRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateAccountSubGroupRequest request);

    Task<bool> DeleteAsync(Guid id);
}