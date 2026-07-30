using FAATPRO.Application.Features.JournalEntries.DTOs;
using FAATPRO.Application.Features.JournalEntries.Interfaces;

using FAATPRO.Domain.Entities.Accounting;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.JournalEntries;


public class JournalEntryService : IJournalEntryService
{

    private readonly ApplicationDbContext _context;


    public JournalEntryService(
        ApplicationDbContext context)
    {
        _context = context;
    }




    public async Task<List<JournalEntryResponse>> GetAllAsync()
    {
        return await _context.JournalEntries
            .Include(x => x.Details)
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


                Details = x.Details
                    .Select(d => new JournalEntryDetailResponse
                    {
                        Id = d.Id,

                        LedgerId = d.LedgerId,

                        Debit = d.Debit,

                        Credit = d.Credit,

                        Narration = d.Narration

                    })
                    .ToList()

            })
            .ToListAsync();
    }






    public async Task<JournalEntryResponse?> GetByIdAsync(
        Guid id)
    {

        var entry = await _context.JournalEntries
            .Include(x => x.Details)
            .FirstOrDefaultAsync(x => x.Id == id);



        if (entry == null)
            return null;



        return MapResponse(entry);
    }







    public async Task<JournalEntryResponse> CreateAsync(
        CreateJournalEntryRequest request)
    {

        decimal totalDebit =
            request.Details.Sum(x => x.Debit);


        decimal totalCredit =
            request.Details.Sum(x => x.Credit);



        if (totalDebit != totalCredit)
        {
            throw new Exception(
                "Debit and Credit must be equal");
        }



        var entry = new FAATPRO.Domain.Entities.Accounting.JournalEntry
        {

            Id = Guid.NewGuid(),

            VoucherNo = request.VoucherNo,

            VoucherDate = request.VoucherDate,

            ReferenceNo = request.ReferenceNo,

            Narration = request.Narration,


            CompanyId = request.CompanyId,

            FinancialYearId = request.FinancialYearId,


            TotalDebit = totalDebit,

            TotalCredit = totalCredit,


            CreatedOn = DateTime.UtcNow,



            Details = request.Details
                .Select(x => new JournalEntryDetail
                {

                    Id = Guid.NewGuid(),

                    LedgerId = x.LedgerId,

                    Debit = x.Debit,

                    Credit = x.Credit,

                    Narration = x.Narration

                })
                .ToList()

        };



        _context.JournalEntries.Add(entry);


        await _context.SaveChangesAsync();



        return MapResponse(entry);

    }








    public async Task<bool> UpdateAsync(
        Guid id,
        CreateJournalEntryRequest request)
    {

        var entry = await _context.JournalEntries
            .Include(x => x.Details)
            .FirstOrDefaultAsync(x => x.Id == id);



        if (entry == null)
            return false;



        decimal totalDebit =
            request.Details.Sum(x => x.Debit);


        decimal totalCredit =
            request.Details.Sum(x => x.Credit);



        if (totalDebit != totalCredit)
        {
            throw new Exception(
                "Debit and Credit must be equal");
        }



        entry.VoucherNo = request.VoucherNo;

        entry.VoucherDate = request.VoucherDate;

        entry.ReferenceNo = request.ReferenceNo;

        entry.Narration = request.Narration;


        entry.TotalDebit = totalDebit;

        entry.TotalCredit = totalCredit;



        _context.JournalEntryDetails
            .RemoveRange(entry.Details);



        entry.Details =
            request.Details
            .Select(x => new JournalEntryDetail
            {

                Id = Guid.NewGuid(),

                JournalEntryId = entry.Id,

                LedgerId = x.LedgerId,

                Debit = x.Debit,

                Credit = x.Credit,

                Narration = x.Narration

            })
            .ToList();



        await _context.SaveChangesAsync();


        return true;

    }








    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var entry = await _context.JournalEntries
            .FirstOrDefaultAsync(x => x.Id == id);



        if (entry == null)
            return false;



        _context.JournalEntries.Remove(entry);


        await _context.SaveChangesAsync();


        return true;

    }








    private static JournalEntryResponse MapResponse(
        FAATPRO.Domain.Entities.Accounting.JournalEntry x)
    {

        return new JournalEntryResponse
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



            Details = x.Details
                .Select(d => new JournalEntryDetailResponse
                {

                    Id = d.Id,

                    LedgerId = d.LedgerId,

                    Debit = d.Debit,

                    Credit = d.Credit,

                    Narration = d.Narration

                })
                .ToList()

        };

    }

}