using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;


public class LedgerPosting : BaseEntity
{

    // =====================================
    // Journal Entry Reference
    // =====================================

    public Guid JournalEntryId { get; set; }



    // =====================================
    // Ledger Reference
    // =====================================

    public Guid LedgerId { get; set; }




    // =====================================
    // Posting Date
    // =====================================

    public DateTime PostingDate { get; set; }




    // =====================================
    // Accounting Amount
    // =====================================

    public decimal Debit { get; set; }


    public decimal Credit { get; set; }




    // =====================================
    // Running Balance
    // =====================================

    public decimal Balance { get; set; }




    // =====================================
    // Narration
    // =====================================

    public string? Narration { get; set; }




    // =====================================
    // Audit
    // =====================================

    public DateTime CreatedOn { get; set; }


    public Guid? CreatedBy { get; set; }




    // =====================================
    // Navigation
    // =====================================

    public JournalEntry JournalEntry { get; set; } = null!;


    public Ledger Ledger { get; set; } = null!;



    // =====================================
    // Posting Details
    // =====================================

    public ICollection<LedgerPostingDetail> Details { get; set; }
        = new List<LedgerPostingDetail>();


}