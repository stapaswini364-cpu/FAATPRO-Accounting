using FAATPRO.Application.Features.AccountGroups.DTOs;
using FAATPRO.Application.Features.AccountGroups.Interfaces;

using AccountGroupEntity = FAATPRO.Domain.Entities.Accounting.AccountGroup;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.AccountGroup;


public class AccountGroupService : IAccountGroupService
{

    private readonly ApplicationDbContext _context;


    public AccountGroupService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<AccountGroupResponse>> GetAllAsync()
    {

        return await _context.AccountGroups

            .OrderBy(x => x.DisplayOrder)

            .Select(x => new AccountGroupResponse
            {

                Id = x.Id,

                Code = x.Code,

                Name = x.Name,

                Nature = x.Nature,

                DisplayOrder = x.DisplayOrder,

                IsActive = x.IsActive,

                CreatedOn = x.CreatedOn

            })

            .ToListAsync();

    }




    public async Task<AccountGroupResponse?> GetByIdAsync(Guid id)
    {

        var group =
            await _context.AccountGroups
            .FirstOrDefaultAsync(x => x.Id == id);


        if(group == null)
            return null;



        return new AccountGroupResponse
        {

            Id = group.Id,

            Code = group.Code,

            Name = group.Name,

            Nature = group.Nature,

            DisplayOrder = group.DisplayOrder,

            IsActive = group.IsActive,

            CreatedOn = group.CreatedOn

        };

    }





    public async Task<AccountGroupResponse> CreateAsync(
        CreateAccountGroupRequest request)
    {

        var group = new AccountGroupEntity
        {

            Id = Guid.NewGuid(),

            Code = request.Code,

            Name = request.Name,

            Nature = request.Nature,

            DisplayOrder = request.DisplayOrder,

            IsActive = request.IsActive,

            CreatedOn = DateTime.UtcNow

        };


        await _context.AccountGroups.AddAsync(group);


        await _context.SaveChangesAsync();


        return await GetByIdAsync(group.Id)
            ?? throw new Exception(
                "Account Group creation failed");

    }






    public async Task<bool> UpdateAsync(
        Guid id,
        CreateAccountGroupRequest request)
    {

        var group =
            await _context.AccountGroups
            .FirstOrDefaultAsync(x => x.Id == id);



        if(group == null)
            return false;



        group.Code = request.Code;

        group.Name = request.Name;

        group.Nature = request.Nature;

        group.DisplayOrder = request.DisplayOrder;

        group.IsActive = request.IsActive;



        await _context.SaveChangesAsync();


        return true;

    }






    public async Task<bool> DeleteAsync(Guid id)
    {

        var group =
            await _context.AccountGroups
            .FirstOrDefaultAsync(x => x.Id == id);



        if(group == null)
            return false;



        _context.AccountGroups.Remove(group);


        await _context.SaveChangesAsync();


        return true;

    }

}