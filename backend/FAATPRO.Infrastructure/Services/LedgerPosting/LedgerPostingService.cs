using FAATPRO.Application.Features.LedgerPosting.DTOs;
using FAATPRO.Application.Features.LedgerPosting.Interfaces;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

using LedgerPostingEntity =
    FAATPRO.Domain.Entities.Accounting.LedgerPosting;


namespace FAATPRO.Infrastructure.Services.LedgerPosting;


public class LedgerPostingService : ILedgerPostingService
{

    private readonly ApplicationDbContext _context;


    public LedgerPostingService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    // ==========================================
    // CREATE POSTING
    // ==========================================

    public async Task CreatePostingAsync(
        Guid journalEntryId)
    {

        var entry =
            await _context.JournalEntries
            .Include(x => x.Details)
            .FirstOrDefaultAsync(
                x => x.Id == journalEntryId
            );


        if(entry == null)
            throw new Exception(
                "Journal Entry not found"
            );



        foreach(var detail in entry.Details)
        {

            var ledger =
                await _context.Ledgers
                .FirstOrDefaultAsync(
                    x => x.Id == detail.LedgerId
                );


            if(ledger == null)
                continue;



            var posting =
                new LedgerPostingEntity
                {

                    Id = Guid.NewGuid(),

                    JournalEntryId =
                        entry.Id,


                    LedgerId =
                        detail.LedgerId,


                    PostingDate =
                        entry.VoucherDate,


                    Debit =
                        detail.Debit,


                    Credit =
                        detail.Credit,


                    Balance =
                        detail.Debit -
                        detail.Credit,


                    Narration =
                        entry.Narration

                };


            await _context.LedgerPostings
                .AddAsync(posting);



            ledger.CurrentBalance +=
                detail.Debit -
                detail.Credit;


            ledger.ModifiedOn =
                DateTime.UtcNow;

        }



        await _context.SaveChangesAsync();

    }






    // ==========================================
    // DELETE POSTING
    // ==========================================

    public async Task DeletePostingAsync(
        Guid journalEntryId)
    {

        var postings =
            await _context.LedgerPostings
            .Where(
                x => x.JournalEntryId == journalEntryId
            )
            .ToListAsync();



        foreach(var posting in postings)
        {

            var ledger =
                await _context.Ledgers
                .FirstOrDefaultAsync(
                    x => x.Id == posting.LedgerId
                );


            if(ledger != null)
            {

                ledger.CurrentBalance -=
                    posting.Debit -
                    posting.Credit;


                ledger.ModifiedOn =
                    DateTime.UtcNow;

            }

        }



        _context.LedgerPostings
            .RemoveRange(postings);



        await _context.SaveChangesAsync();

    }







    // ==========================================
    // REBUILD POSTING
    // ==========================================

    public async Task RebuildPostingAsync(
        Guid journalEntryId)
    {

        await DeletePostingAsync(
            journalEntryId
        );


        await CreatePostingAsync(
            journalEntryId
        );

    }







    // ==========================================
    // LEDGER STATEMENT
    // ==========================================

    public async Task<List<LedgerPostingResponse>>
        GetLedgerStatementAsync(
            Guid ledgerId)
    {


        var ledger =
            await _context.Ledgers
            .FirstOrDefaultAsync(
                x => x.Id == ledgerId
            );


        if(ledger == null)
            throw new Exception(
                "Ledger not found"
            );



        var postings =
            await _context.LedgerPostings

            .Where(
                x => x.LedgerId == ledgerId
            )

            .OrderBy(
                x => x.PostingDate
            )

            .ToListAsync();



        decimal balance =
            ledger.OpeningBalance;



        var result =
            new List<LedgerPostingResponse>();



        foreach(var item in postings)
        {

            balance +=
                item.Debit -
                item.Credit;



            result.Add(
                new LedgerPostingResponse
                {

                    Id = item.Id,

                    LedgerId =
                        item.LedgerId,


                    LedgerName =
                        ledger.Name,


                    PostingDate =
                        item.PostingDate,


                    Debit =
                        item.Debit,


                    Credit =
                        item.Credit,


                    Balance =
                        balance,


                    Narration =
                        item.Narration

                });

        }



        return result;

    }

}