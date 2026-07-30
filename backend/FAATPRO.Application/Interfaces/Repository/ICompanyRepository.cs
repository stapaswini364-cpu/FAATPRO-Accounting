using FAATPRO.Domain.Entities;

namespace FAATPRO.Application.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();

    Task<Company?> GetByIdAsync(Guid id);

    Task<Company?> GetByCodeAsync(string companyCode);

    Task AddAsync(Company company);

    Task UpdateAsync(Company company);

    Task DeleteAsync(Guid id);

    Task<bool> ExistsAsync(string companyCode);

    Task SaveChangesAsync();
}