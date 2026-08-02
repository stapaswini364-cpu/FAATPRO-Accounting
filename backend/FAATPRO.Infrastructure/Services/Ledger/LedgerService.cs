using FAATPRO.Application.Features.Ledgers.DTOs;
using FAATPRO.Application.Features.Ledgers.Interfaces;

using LedgerEntity = FAATPRO.Domain.Entities.Accounting.Ledger;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Ledger;


public class LedgerService : ILedgerService
{

    private readonly ApplicationDbContext _context;


    public LedgerService(ApplicationDbContext context)
    {
        _context = context;
    }






    public async Task<List<LedgerResponse>> GetAllAsync()
    {

        return await _context.Ledgers

            .Select(x => new LedgerResponse
            {

                Id = x.Id,

                Code = x.Code,

                Name = x.Name,


                AccountHeadId = x.AccountHeadId,

                AccountGroupId = x.AccountGroupId,

                AccountSubGroupId = x.AccountSubGroupId,


                OpeningBalance = x.OpeningBalance,

                BalanceType = x.BalanceType,


                Address = x.Address,

                Mobile = x.Mobile,

                Email = x.Email,

                GSTIN = x.GSTIN,


                IsActive = x.IsActive,

                CreatedOn = x.CreatedOn


            })

            .ToListAsync();

    }









    public async Task<LedgerResponse?> GetByIdAsync(Guid id)
    {


        var ledger = await _context.Ledgers

            .Include(x => x.JournalEntryDetails)

            .ThenInclude(x => x.JournalEntry)

            .FirstOrDefaultAsync(x => x.Id == id);





        if (ledger == null)

            return null;





        var response = MapResponse(ledger);






        response.Transactions =

            ledger.JournalEntryDetails

            .OrderBy(x => x.JournalEntry.VoucherDate)

            .Select(x => new LedgerTransactionResponse
            {

                Date =
                    x.JournalEntry.VoucherDate,


                VoucherNo =
                    x.JournalEntry.VoucherNo,


                Narration =
                    x.JournalEntry.Narration
                    ??
                    x.Narration,


                Debit =
                    x.Debit,


                Credit =
                    x.Credit


            })

            .ToList();







        var debit =

            response.Transactions

            .Sum(x => x.Debit);





        var credit =

            response.Transactions

            .Sum(x => x.Credit);






        response.ClosingBalance =

            ledger.OpeningBalance

            +

            debit

            -

            credit;





        return response;

    }









    public async Task<LedgerResponse> CreateAsync(
        CreateLedgerRequest request)
    {


        var ledger = new LedgerEntity
        {

            Id = Guid.NewGuid(),

            Code = request.Code,

            Name = request.Name,


            AccountHeadId = request.AccountHeadId,

            AccountGroupId = request.AccountGroupId,

            AccountSubGroupId = request.AccountSubGroupId,


            OpeningBalance = request.OpeningBalance,

            BalanceType = request.BalanceType,


            Address = request.Address,

            Mobile = request.Mobile,

            Email = request.Email,

            GSTIN = request.GSTIN,


            IsActive = request.IsActive,


            CreatedOn = DateTime.UtcNow

        };



        _context.Ledgers.Add(ledger);


        await _context.SaveChangesAsync();



        return MapResponse(ledger);

    }











    public async Task<bool> UpdateAsync(
        Guid id,
        CreateLedgerRequest request)
    {

        var ledger = await _context.Ledgers

            .FirstOrDefaultAsync(x => x.Id == id);



        if (ledger == null)

            return false;




        ledger.Code = request.Code;

        ledger.Name = request.Name;


        ledger.AccountHeadId = request.AccountHeadId;

        ledger.AccountGroupId = request.AccountGroupId;

        ledger.AccountSubGroupId = request.AccountSubGroupId;



        ledger.OpeningBalance = request.OpeningBalance;

        ledger.BalanceType = request.BalanceType;



        ledger.Address = request.Address;

        ledger.Mobile = request.Mobile;

        ledger.Email = request.Email;

        ledger.GSTIN = request.GSTIN;



        ledger.IsActive = request.IsActive;


        ledger.ModifiedOn = DateTime.UtcNow;




        await _context.SaveChangesAsync();



        return true;

    }









    public async Task<bool> DeleteAsync(Guid id)
    {

        var ledger = await _context.Ledgers

            .FirstOrDefaultAsync(x => x.Id == id);



        if (ledger == null)

            return false;



        _context.Ledgers.Remove(ledger);


        await _context.SaveChangesAsync();



        return true;

    }









    private static LedgerResponse MapResponse(
        LedgerEntity x)
    {


        return new LedgerResponse
        {

            Id = x.Id,


            Code = x.Code,


            Name = x.Name,


            AccountHeadId = x.AccountHeadId,


            AccountGroupId = x.AccountGroupId,


            AccountSubGroupId = x.AccountSubGroupId,


            OpeningBalance = x.OpeningBalance,


            BalanceType = x.BalanceType,



            Address = x.Address,


            Mobile = x.Mobile,


            Email = x.Email,


            GSTIN = x.GSTIN,



            IsActive = x.IsActive,


            CreatedOn = x.CreatedOn


        };

    }


}