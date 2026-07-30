using FAATPRO.Application.Interfaces.Repositories;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _context.Companies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Company?> GetByCodeAsync(string companyCode)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(x => x.CompanyCode == companyCode);
    }

    public async Task<bool> ExistsAsync(string companyCode)
    {
        return await _context.Companies
            .AnyAsync(x => x.CompanyCode == companyCode);
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
    }

    public Task UpdateAsync(Company company)
    {
        _context.Companies.Update(company);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var company = await _context.Companies.FindAsync(id);

        if (company != null)
        {
            _context.Companies.Remove(company);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
