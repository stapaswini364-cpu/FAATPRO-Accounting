using FAATPRO.Application.Features.Companies.DTOs;

namespace FAATPRO.Application.Features.Companies.Interfaces;

public interface ICompanyService
{
    Task<List<CompanyResponse>> GetAllAsync();

    Task<CompanyResponse?> GetByIdAsync(Guid id);

    Task<CompanyResponse> CreateAsync(
        CreateCompanyRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateCompanyRequest request);

    Task<bool> DeleteAsync(Guid id);
}