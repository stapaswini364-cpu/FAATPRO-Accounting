using FAATPRO.Application.Features.AccountHeads.DTOs;


namespace FAATPRO.Application.Features.AccountHeads.Interfaces;


public interface IAccountHeadService
{

    Task<List<AccountHeadResponse>> GetAllAsync();


    Task<AccountHeadResponse?> GetByIdAsync(
        Guid id);


    Task<AccountHeadResponse> CreateAsync(
        CreateAccountHeadRequest request);


    Task<bool> UpdateAsync(
        Guid id,
        CreateAccountHeadRequest request);


    Task<bool> DeleteAsync(
        Guid id);

}