using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;


public class LedgerPostingDetail : BaseEntity
{

    public Guid LedgerPostingId { get; set; }



    public Guid LedgerId { get; set; }



    public decimal Debit { get; set; }



    public decimal Credit { get; set; }



    public string? Particulars { get; set; }



    // Navigation


    public LedgerPosting LedgerPosting { get; set; } = null!;


    public Ledger Ledger { get; set; } = null!;

}