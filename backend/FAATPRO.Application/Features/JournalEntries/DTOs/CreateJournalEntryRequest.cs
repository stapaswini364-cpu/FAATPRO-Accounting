namespace FAATPRO.Application.Features.JournalEntries.DTOs;

public class CreateJournalEntryRequest
{
    public string VoucherNo { get; set; } = null!;

    public DateTime VoucherDate { get; set; }

    public string? ReferenceNo { get; set; }

    public string? Narration { get; set; }


    public Guid CompanyId { get; set; }

    public Guid FinancialYearId { get; set; }


    public List<JournalEntryDetailRequest> Details { get; set; }
        = new();
}



public class JournalEntryDetailRequest
{
    public Guid LedgerId { get; set; }


    public decimal Debit { get; set; }

    public decimal Credit { get; set; }


    public string? Narration { get; set; }
}