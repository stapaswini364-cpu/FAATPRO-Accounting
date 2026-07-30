using FAATPRO.Application.Features.Branches.DTOs;
using FAATPRO.Application.Features.Branches.Interfaces;

using BranchEntity = FAATPRO.Domain.Entities.Branch;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Branch;


public class BranchService : IBranchService
{
    private readonly ApplicationDbContext _context;


    public BranchService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<BranchResponse>> GetAllAsync()
    {
        return await _context.Branches

            .Select(x => new BranchResponse
            {
                Id = x.Id,

                CompanyId = x.CompanyId,

                BranchCode = x.BranchCode,

                BranchName = x.BranchName,

                Address = x.Address,

                City = x.City,

                State = x.State,

                Country = x.Country,

                Phone = x.Phone,

                Email = x.Email,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();
    }



    public async Task<BranchResponse?> GetByIdAsync(Guid id)
    {
        var branch =
            await _context.Branches
            .FirstOrDefaultAsync(x => x.Id == id);


        if (branch == null)
            return null;


        return new BranchResponse
        {
            Id = branch.Id,

            CompanyId = branch.CompanyId,

            BranchCode = branch.BranchCode,

            BranchName = branch.BranchName,

            Address = branch.Address,

            City = branch.City,

            State = branch.State,

            Country = branch.Country,

            Phone = branch.Phone,

            Email = branch.Email,

            IsActive = branch.IsActive,

            CreatedAt = branch.CreatedAt
        };
    }



    public async Task<BranchResponse> CreateAsync(
        CreateBranchRequest request)
    {

        var branch = new BranchEntity
        {
            Id = Guid.NewGuid(),

            CompanyId = request.CompanyId,

            BranchCode = request.BranchCode,

            BranchName = request.BranchName,

            Address = request.Address,

            City = request.City,

            State = request.State,

            Country = request.Country,

            Phone = request.Phone,

            Email = request.Email
        };


        await _context.Branches.AddAsync(branch);

        await _context.SaveChangesAsync();


        return await GetByIdAsync(branch.Id)
            ?? throw new Exception("Branch creation failed");
    }



    public async Task<bool> UpdateAsync(
        Guid id,
        CreateBranchRequest request)
    {

        var branch =
            await _context.Branches
            .FirstOrDefaultAsync(x => x.Id == id);


        if (branch == null)
            return false;


        branch.CompanyId = request.CompanyId;

        branch.BranchCode = request.BranchCode;

        branch.BranchName = request.BranchName;

        branch.Address = request.Address;

        branch.City = request.City;

        branch.State = request.State;

        branch.Country = request.Country;

        branch.Phone = request.Phone;

        branch.Email = request.Email;


        await _context.SaveChangesAsync();


        return true;
    }



    public async Task<bool> DeleteAsync(Guid id)
    {

        var branch =
            await _context.Branches
            .FirstOrDefaultAsync(x => x.Id == id);


        if (branch == null)
            return false;


        _context.Branches.Remove(branch);


        await _context.SaveChangesAsync();


        return true;
    }
}