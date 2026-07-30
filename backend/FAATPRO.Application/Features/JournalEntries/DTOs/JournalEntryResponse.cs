namespace FAATPRO.Application.Features.JournalEntries.DTOs;

public class JournalEntryResponse
{
    public Guid Id { get; set; }

    public string VoucherNo { get; set; } = null!;

    public DateTime VoucherDate { get; set; }

    public string? ReferenceNo { get; set; }

    public string? Narration { get; set; }


    public decimal TotalDebit { get; set; }

    public decimal TotalCredit { get; set; }


    public Guid CompanyId { get; set; }

    public Guid FinancialYearId { get; set; }


    public DateTime CreatedOn { get; set; }


    public List<JournalEntryDetailResponse> Details { get; set; }
        = new();
}



public class JournalEntryDetailResponse
{
    public Guid Id { get; set; }

    public Guid LedgerId { get; set; }

    public decimal Debit { get; set; }

    public decimal Credit { get; set; }

    public string? Narration { get; set; }
}