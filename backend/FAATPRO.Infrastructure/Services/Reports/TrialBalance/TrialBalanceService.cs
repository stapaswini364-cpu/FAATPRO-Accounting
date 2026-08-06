using FAATPRO.Application.Features.Reports.TrialBalance.DTOs;
using FAATPRO.Application.Features.Reports.TrialBalance.Interfaces;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Reports.TrialBalance;


public class TrialBalanceService : ITrialBalanceService
{

    private readonly ApplicationDbContext _context;


    public TrialBalanceService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<TrialBalanceResponse>> GetAsync()
    {

        var ledgers =
            await _context.Ledgers
            .ToListAsync();



        var details =
            await _context.JournalEntryDetails
            .Include(x => x.JournalEntry)
            .ToListAsync();



        var result =
            new List<TrialBalanceResponse>();



        foreach (var ledger in ledgers)
        {

            var ledgerDetails =
                details
                .Where(x => x.LedgerId == ledger.Id)
                .ToList();



            var debit =
                ledgerDetails
                .Sum(x => x.Debit);



            var credit =
                ledgerDetails
                .Sum(x => x.Credit);



            result.Add(new TrialBalanceResponse
            {

                LedgerId = ledger.Id,


                LedgerName = ledger.Name,


                OpeningBalance =
                    ledger.OpeningBalance,


                Debit = debit,


                Credit = credit,


                ClosingBalance =
                    ledger.OpeningBalance
                    + debit
                    - credit

            });

        }



        return result;

    }

}