using FAATPRO.Application.Features.Users.DTOs;

namespace FAATPRO.Application.Features.Users.Interfaces;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();

    Task<UserResponse?> GetByIdAsync(Guid id);

    Task<UserResponse> CreateAsync(
        CreateUserRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        UpdateUserRequest request);

    Task<bool> DeleteAsync(Guid id);
}