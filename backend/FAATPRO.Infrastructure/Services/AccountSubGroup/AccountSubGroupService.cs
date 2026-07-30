using FAATPRO.Application.Features.AccountSubGroups.DTOs;
using FAATPRO.Application.Features.AccountSubGroups.Interfaces;

using FAATPRO.Infrastructure.Persistence;

using AccountSubGroupEntity = FAATPRO.Domain.Entities.Accounting.AccountSubGroup;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.AccountSubGroup;


public class AccountSubGroupService : IAccountSubGroupService
{
    private readonly ApplicationDbContext _context;


    public AccountSubGroupService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<AccountSubGroupResponse>> GetAllAsync()
    {
        return await _context.AccountSubGroups

            .OrderBy(x => x.DisplayOrder)

            .Select(x => new AccountSubGroupResponse
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                AccountGroupId = x.AccountGroupId,
                Nature = x.Nature,
                DisplayOrder = x.DisplayOrder,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn
            })

            .ToListAsync();
    }



    public async Task<AccountSubGroupResponse?> GetByIdAsync(Guid id)
    {
        var item = await _context.AccountSubGroups
            .FirstOrDefaultAsync(x => x.Id == id);


        if (item == null)
            return null;


        return new AccountSubGroupResponse
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            AccountGroupId = item.AccountGroupId,
            Nature = item.Nature,
            DisplayOrder = item.DisplayOrder,
            IsActive = item.IsActive,
            CreatedOn = item.CreatedOn
        };
    }



    public async Task<AccountSubGroupResponse> CreateAsync(
        CreateAccountSubGroupRequest request)
    {
        var entity = new AccountSubGroupEntity
        {
            Id = Guid.NewGuid(),

            Code = request.Code,

            Name = request.Name,

            AccountGroupId = request.AccountGroupId,

            Nature = request.Nature,

            DisplayOrder = request.DisplayOrder,

            IsActive = request.IsActive,

            CreatedOn = DateTime.UtcNow
        };


        await _context.AccountSubGroups.AddAsync(entity);

        await _context.SaveChangesAsync();


        return await GetByIdAsync(entity.Id)
            ?? throw new Exception("Creation failed");
    }



    public async Task<bool> UpdateAsync(
        Guid id,
        CreateAccountSubGroupRequest request)
    {
        var entity =
            await _context.AccountSubGroups
            .FirstOrDefaultAsync(x => x.Id == id);


        if (entity == null)
            return false;


        entity.Code = request.Code;

        entity.Name = request.Name;

        entity.AccountGroupId = request.AccountGroupId;

        entity.Nature = request.Nature;

        entity.DisplayOrder = request.DisplayOrder;

        entity.IsActive = request.IsActive;


        await _context.SaveChangesAsync();


        return true;
    }



    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity =
            await _context.AccountSubGroups
            .FirstOrDefaultAsync(x => x.Id == id);


        if (entity == null)
            return false;


        _context.AccountSubGroups.Remove(entity);

        await _context.SaveChangesAsync();


        return true;
    }
}