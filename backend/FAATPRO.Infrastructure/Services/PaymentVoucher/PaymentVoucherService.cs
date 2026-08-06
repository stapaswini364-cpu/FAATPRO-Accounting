using FAATPRO.Application.DTOs.PaymentVoucher;
using FAATPRO.Infrastructure.Persistence;

using JournalEntryEntity = FAATPRO.Domain.Entities.Accounting.JournalEntry;
using JournalEntryDetailEntity = FAATPRO.Domain.Entities.Accounting.JournalEntryDetail;
using LedgerPostingEntity = FAATPRO.Domain.Entities.Accounting.LedgerPosting;


namespace FAATPRO.Infrastructure.Services.PaymentVoucher;


public class PaymentVoucherService
{

    private readonly ApplicationDbContext _context;


    public PaymentVoucherService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<Guid> CreateAsync(
        CreatePaymentVoucherRequest request)
    {

        var voucherDateUtc =
            DateTime.SpecifyKind(
                request.VoucherDate,
                DateTimeKind.Utc
            );


        var nowUtc = DateTime.UtcNow;



        var journalEntry =
            new JournalEntryEntity
            {

                VoucherNo =
                    "PV-" + DateTime.Now.Ticks,


                VoucherDate =
                    voucherDateUtc,


                Narration =
                    request.Narration,


                TotalDebit =
                    request.Amount,


                TotalCredit =
                    request.Amount,


                CompanyId =
                    request.CompanyId,


                FinancialYearId =
                    request.FinancialYearId,


                CreatedOn =
                    nowUtc,


                Details =
                    new List<JournalEntryDetailEntity>()

            };



        journalEntry.Details.Add(

            new JournalEntryDetailEntity
            {

                LedgerId =
                    request.ExpenseLedgerId,


                Debit =
                    request.Amount,


                Credit =
                    0

            });



        journalEntry.Details.Add(

            new JournalEntryDetailEntity
            {

                LedgerId =
                    request.CashBankLedgerId,


                Debit =
                    0,


                Credit =
                    request.Amount

            });



        _context.JournalEntries.Add(journalEntry);



        await _context.SaveChangesAsync();



        // ===============================
        // Ledger Posting Creation
        // ===============================


        var expensePosting =
            new LedgerPostingEntity
            {

                JournalEntryId =
                    journalEntry.Id,


                LedgerId =
                    request.ExpenseLedgerId,


                Debit =
                    request.Amount,


                Credit =
                    0,


                Balance =
                    request.Amount,


                PostingDate =
                    voucherDateUtc,


                Narration =
                    request.Narration

            };



        var cashPosting =
            new LedgerPostingEntity
            {

                JournalEntryId =
                    journalEntry.Id,


                LedgerId =
                    request.CashBankLedgerId,


                Debit =
                    0,


                Credit =
                    request.Amount,


                Balance =
                    -request.Amount,


                PostingDate =
                    voucherDateUtc,


                Narration =
                    request.Narration

            };



        _context.LedgerPostings.Add(expensePosting);

        _context.LedgerPostings.Add(cashPosting);



        await _context.SaveChangesAsync();



        return journalEntry.Id;

    }

}