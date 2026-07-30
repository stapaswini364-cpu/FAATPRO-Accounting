using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;

public class JournalEntryDetail : BaseEntity
{
    public Guid JournalEntryId { get; set; }

    public Guid LedgerId { get; set; }


    public decimal Debit { get; set; }

    public decimal Credit { get; set; }


    public string? Narration { get; set; }



    // Navigation

    public JournalEntry JournalEntry { get; set; } = null!;

    public Ledger Ledger { get; set; } = null!;
}