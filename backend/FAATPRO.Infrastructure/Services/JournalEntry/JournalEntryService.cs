using FAATPRO.Application.Features.JournalEntries.DTOs;
using FAATPRO.Application.Features.JournalEntries.Interfaces;

using FAATPRO.Application.Features.LedgerPosting.Interfaces;

using JournalEntryEntity = FAATPRO.Domain.Entities.Accounting.JournalEntry;
using JournalEntryDetailEntity = FAATPRO.Domain.Entities.Accounting.JournalEntryDetail;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.JournalEntry;


public class JournalEntryService : IJournalEntryService
{

    private readonly ApplicationDbContext _context;

    private readonly ILedgerPostingService _ledgerPostingService;



    public JournalEntryService(
        ApplicationDbContext context,
        ILedgerPostingService ledgerPostingService)
    {
        _context = context;

        _ledgerPostingService = ledgerPostingService;
    }





    public async Task<List<JournalEntryResponse>> GetAllAsync()
    {

        return await _context.JournalEntries

            .Include(x => x.Details)

            .ThenInclude(x => x.Ledger)

            .OrderByDescending(x => x.VoucherDate)

            .Select(x => new JournalEntryResponse
            {

                Id = x.Id,

                VoucherNo = x.VoucherNo,

                VoucherDate = x.VoucherDate,

                ReferenceNo = x.ReferenceNo,

                Narration = x.Narration,

                TotalDebit = x.TotalDebit,

                TotalCredit = x.TotalCredit,

                CompanyId = x.CompanyId,

                FinancialYearId = x.FinancialYearId,

                CreatedOn = x.CreatedOn,


                Details = x.Details.Select(d => new JournalEntryDetailResponse
                {

                    LedgerId = d.LedgerId,

                    LedgerName = d.Ledger.Name,

                    Debit = d.Debit,

                    Credit = d.Credit,

                    Narration = d.Narration


                }).ToList()


            })

            .ToListAsync();

    }








    public async Task<JournalEntryResponse?> GetByIdAsync(Guid id)
    {

        var entry =
            await _context.JournalEntries

            .Include(x => x.Details)

            .ThenInclude(x => x.Ledger)

            .FirstOrDefaultAsync(
                x => x.Id == id
            );



        if(entry == null)
            return null;



        return new JournalEntryResponse
        {

            Id = entry.Id,

            VoucherNo = entry.VoucherNo,

            VoucherDate = entry.VoucherDate,

            ReferenceNo = entry.ReferenceNo,

            Narration = entry.Narration,

            TotalDebit = entry.TotalDebit,

            TotalCredit = entry.TotalCredit,

            CompanyId = entry.CompanyId,

            FinancialYearId = entry.FinancialYearId,

            CreatedOn = entry.CreatedOn,


            Details =
                entry.Details.Select(d =>
                new JournalEntryDetailResponse
                {

                    LedgerId = d.LedgerId,

                    LedgerName = d.Ledger.Name,

                    Debit = d.Debit,

                    Credit = d.Credit,

                    Narration = d.Narration


                }).ToList()

        };

    }










    public async Task<JournalEntryResponse> CreateAsync(
        CreateJournalEntryRequest request)
    {

        var totalDebit =
            request.Details.Sum(x => x.Debit);


        var totalCredit =
            request.Details.Sum(x => x.Credit);



        if(totalDebit != totalCredit)
        {
            throw new Exception(
                "Debit and Credit must be equal."
            );
        }



        var entry = new JournalEntryEntity
        {

            Id = Guid.NewGuid(),

            VoucherNo = request.VoucherNo,


            VoucherDate =
                DateTime.SpecifyKind(
                    request.VoucherDate,
                    DateTimeKind.Utc
                ),


            ReferenceNo = request.ReferenceNo,

            Narration = request.Narration,


            TotalDebit = totalDebit,

            TotalCredit = totalCredit,


            CompanyId = request.CompanyId,

            FinancialYearId = request.FinancialYearId,


            CreatedOn = DateTime.UtcNow

        };





        foreach(var item in request.Details)
        {

            entry.Details.Add(

                new JournalEntryDetailEntity
                {

                    Id = Guid.NewGuid(),

                    LedgerId = item.LedgerId,

                    Debit = item.Debit,

                    Credit = item.Credit,

                    Narration = item.Narration

                }

            );

        }





        await _context.JournalEntries
            .AddAsync(entry);


        await _context.SaveChangesAsync();





        await _ledgerPostingService
            .CreatePostingAsync(entry.Id);





        return await GetByIdAsync(entry.Id)

            ?? throw new Exception(
                "Journal Entry creation failed."
            );

    }










    public async Task<JournalEntryResponse> UpdateAsync(
        Guid id,
        CreateJournalEntryRequest request)
    {

        var entry =
            await _context.JournalEntries

            .Include(x => x.Details)

            .FirstOrDefaultAsync(
                x => x.Id == id
            );



        if(entry == null)
        {
            throw new Exception(
                "Journal Entry not found."
            );
        }




        var totalDebit =
            request.Details.Sum(x => x.Debit);


        var totalCredit =
            request.Details.Sum(x => x.Credit);



        if(totalDebit != totalCredit)
        {
            throw new Exception(
                "Debit and Credit must be equal."
            );
        }




        entry.VoucherNo =
            request.VoucherNo;


        entry.VoucherDate =
            DateTime.SpecifyKind(
                request.VoucherDate,
                DateTimeKind.Utc
            );


        entry.ReferenceNo =
            request.ReferenceNo;


        entry.Narration =
            request.Narration;


        entry.CompanyId =
            request.CompanyId;


        entry.FinancialYearId =
            request.FinancialYearId;


        entry.TotalDebit =
            totalDebit;


        entry.TotalCredit =
            totalCredit;





        _context.JournalEntryDetails
            .RemoveRange(entry.Details);


        entry.Details.Clear();





        foreach(var item in request.Details)
        {

            entry.Details.Add(

                new JournalEntryDetailEntity
                {

                    Id = Guid.NewGuid(),

                    LedgerId = item.LedgerId,

                    Debit = item.Debit,

                    Credit = item.Credit,

                    Narration = item.Narration

                }

            );

        }





        await _context.SaveChangesAsync();





        // Rebuild Ledger Posting

        await _ledgerPostingService
            .RebuildPostingAsync(id);





        return await GetByIdAsync(id)

            ?? throw new Exception(
                "Journal Entry update failed."
            );

    }










    public async Task<bool> DeleteAsync(Guid id)
    {

        var entry =
            await _context.JournalEntries

            .Include(x => x.Details)

            .FirstOrDefaultAsync(
                x => x.Id == id
            );



        if(entry == null)
            return false;





        // Remove Ledger Posting First

        await _ledgerPostingService
            .DeletePostingAsync(id);





        _context.JournalEntryDetails
            .RemoveRange(entry.Details);




        _context.JournalEntries
            .Remove(entry);





        await _context.SaveChangesAsync();




        return true;

    }


}