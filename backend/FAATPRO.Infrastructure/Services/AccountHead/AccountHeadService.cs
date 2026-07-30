using FAATPRO.Application.Features.AccountHeads.DTOs;
using FAATPRO.Application.Features.AccountHeads.Interfaces;

using AccountHeadEntity = FAATPRO.Domain.Entities.Accounting.AccountHead;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.AccountHead;


public class AccountHeadService : IAccountHeadService
{

    private readonly ApplicationDbContext _context;


    public AccountHeadService(
        ApplicationDbContext context)
    {
        _context = context;
    }







    public async Task<List<AccountHeadResponse>> GetAllAsync()
    {

        return await _context.AccountHeads

            .OrderBy(x => x.DisplayOrder)

            .Select(x => new AccountHeadResponse
            {

                Id = x.Id,

                Code = x.Code,

                Name = x.Name,

                Nature = x.Nature,

                DisplayOrder = x.DisplayOrder,

                IsSystem = x.IsSystem,

                IsActive = x.IsActive,

                CreatedOn = x.CreatedOn

            })

            .ToListAsync();

    }









    public async Task<AccountHeadResponse?> GetByIdAsync(
        Guid id)
    {

        var accountHead =
            await _context.AccountHeads
            .FirstOrDefaultAsync(x => x.Id == id);



        if (accountHead == null)
            return null;




        return new AccountHeadResponse
        {

            Id = accountHead.Id,

            Code = accountHead.Code,

            Name = accountHead.Name,

            Nature = accountHead.Nature,

            DisplayOrder = accountHead.DisplayOrder,

            IsSystem = accountHead.IsSystem,

            IsActive = accountHead.IsActive,

            CreatedOn = accountHead.CreatedOn

        };

    }









    public async Task<AccountHeadResponse> CreateAsync(
        CreateAccountHeadRequest request)
    {

        var accountHead = new AccountHeadEntity
        {

            Id = Guid.NewGuid(),

            Code = request.Code,

            Name = request.Name,

            Nature = request.Nature,

            DisplayOrder = request.DisplayOrder,

            IsSystem = request.IsSystem,

            IsActive = request.IsActive,

            CreatedOn = DateTime.UtcNow

        };




        await _context.AccountHeads.AddAsync(accountHead);


        await _context.SaveChangesAsync();




        return await GetByIdAsync(accountHead.Id)

            ?? throw new Exception(
                "Account Head creation failed");

    }









    public async Task<bool> UpdateAsync(
        Guid id,
        CreateAccountHeadRequest request)
    {

        var accountHead =
            await _context.AccountHeads
            .FirstOrDefaultAsync(x => x.Id == id);



        if (accountHead == null)
            return false;




        accountHead.Code = request.Code;

        accountHead.Name = request.Name;

        accountHead.Nature = request.Nature;

        accountHead.DisplayOrder = request.DisplayOrder;

        accountHead.IsActive = request.IsActive;



        await _context.SaveChangesAsync();


        return true;

    }









    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var accountHead =
            await _context.AccountHeads
            .FirstOrDefaultAsync(x => x.Id == id);



        if (accountHead == null)
            return false;




        _context.AccountHeads.Remove(accountHead);


        await _context.SaveChangesAsync();



        return true;

    }

}