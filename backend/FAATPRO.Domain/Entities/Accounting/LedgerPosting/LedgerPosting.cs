using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;


public class LedgerPosting : BaseEntity
{

    public Guid JournalEntryId { get; set; }


    public Guid LedgerId { get; set; }



    public decimal Debit { get; set; }


    public decimal Credit { get; set; }



    public decimal Balance { get; set; }



    public DateTime PostingDate { get; set; }



    public string? Narration { get; set; }



    // Navigation

    public JournalEntry JournalEntry { get; set; } = null!;


    public Ledger Ledger { get; set; } = null!;



    public ICollection<LedgerPostingDetail> Details { get; set; }
        = new List<LedgerPostingDetail>();

}