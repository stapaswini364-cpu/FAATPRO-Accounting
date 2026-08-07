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

    // ==========================================
    // Trial Balance
    // ==========================================

    public async Task<List<TrialBalanceResponse>> GetAsync()
    {
        var result =
            await _context.Ledgers

            .GroupJoin(
                _context.LedgerPostings,
                ledger => ledger.Id,
                posting => posting.LedgerId,
                (ledger, postings) => new TrialBalanceResponse
                {
                    LedgerId = ledger.Id,

                    LedgerName = ledger.Name,

                    OpeningBalance = ledger.OpeningBalance,

                    Debit = postings.Sum(x => x.Debit),

                    Credit = postings.Sum(x => x.Credit),

                    ClosingBalance =
                        ledger.OpeningBalance +
                        postings.Sum(x => x.Debit) -
                        postings.Sum(x => x.Credit)
                })

            .OrderBy(x => x.LedgerName)

            .ToListAsync();

        return result;
    }
}