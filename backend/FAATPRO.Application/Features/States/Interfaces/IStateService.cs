using FAATPRO.Application.Features.States.DTOs;


namespace FAATPRO.Application.Features.States.Interfaces;


public interface IStateService
{

    Task<List<StateResponse>> GetAllAsync();


    Task<StateResponse?> GetByIdAsync(
        Guid id);


    Task<StateResponse> CreateAsync(
        CreateStateRequest request);


    Task<bool> UpdateAsync(
        Guid id,
        CreateStateRequest request);


    Task<bool> DeleteAsync(
        Guid id);

}