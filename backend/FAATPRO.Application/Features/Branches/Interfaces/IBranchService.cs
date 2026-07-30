using FAATPRO.Application.Features.Branches.DTOs;

namespace FAATPRO.Application.Features.Branches.Interfaces;

public interface IBranchService
{
    Task<List<BranchResponse>> GetAllAsync();

    Task<BranchResponse?> GetByIdAsync(Guid id);

    Task<BranchResponse> CreateAsync(
        CreateBranchRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateBranchRequest request);

    Task<bool> DeleteAsync(Guid id);
}