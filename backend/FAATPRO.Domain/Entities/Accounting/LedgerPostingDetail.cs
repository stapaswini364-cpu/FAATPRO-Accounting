using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;


public class LedgerPostingDetail : BaseEntity
{

    // =====================================
    // Ledger Posting Reference
    // =====================================

    public Guid LedgerPostingId { get; set; }



    // =====================================
    // Ledger Reference
    // =====================================

    public Guid LedgerId { get; set; }




    // =====================================
    // Amount
    // =====================================

    public decimal Debit { get; set; }


    public decimal Credit { get; set; }




    // =====================================
    // Narration
    // =====================================

    public string? Narration { get; set; }




    // =====================================
    // Navigation
    // =====================================

    public LedgerPosting LedgerPosting { get; set; } = null!;


    public Ledger Ledger { get; set; } = null!;


}