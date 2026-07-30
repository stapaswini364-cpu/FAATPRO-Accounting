using FAATPRO.Application.Features.AccountGroups.DTOs;


namespace FAATPRO.Application.Features.AccountGroups.Interfaces;


public interface IAccountGroupService
{

    Task<List<AccountGroupResponse>> GetAllAsync();


    Task<AccountGroupResponse?> GetByIdAsync(
        Guid id);


    Task<AccountGroupResponse> CreateAsync(
        CreateAccountGroupRequest request);


    Task<bool> UpdateAsync(
        Guid id,
        CreateAccountGroupRequest request);


    Task<bool> DeleteAsync(
        Guid id);

}