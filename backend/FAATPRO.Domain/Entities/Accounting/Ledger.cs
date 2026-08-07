using FAATPRO.Domain.Common;
using FAATPRO.Domain.Enums;

namespace FAATPRO.Domain.Entities.Accounting;

public class Ledger : BaseEntity
{

    // ==========================
    // Basic Information
    // ==========================

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;



    // ==========================
    // Account Hierarchy
    // ==========================

    public Guid AccountHeadId { get; set; }

    public Guid AccountGroupId { get; set; }

    public Guid? AccountSubGroupId { get; set; }



    // ==========================
    // Opening Balance
    // ==========================

    public decimal OpeningBalance { get; set; }

    public BalanceType BalanceType { get; set; }



    // ==========================
    // Running Balance
    // ==========================

    public decimal CurrentBalance { get; set; }



    // ==========================
    // Contact Details
    // ==========================

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }



    // ==========================
    // Tax
    // ==========================

    public string? GSTIN { get; set; }



    // ==========================
    // Status
    // ==========================

    public bool IsActive { get; set; } = true;



    // ==========================
    // Audit
    // ==========================

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }



    // ==========================
    // Navigation
    // ==========================

    public AccountHead AccountHead { get; set; } = null!;

    public AccountGroup AccountGroup { get; set; } = null!;

    public AccountSubGroup? AccountSubGroup { get; set; }



    // ==========================
    // Journal Entry
    // ==========================

    public ICollection<JournalEntryDetail> JournalEntryDetails { get; set; }
        = new List<JournalEntryDetail>();



    // ==========================
    // Ledger Posting
    // ==========================

    public ICollection<LedgerPosting> LedgerPostings { get; set; }
        = new List<LedgerPosting>();


    public ICollection<LedgerPostingDetail> LedgerPostingDetails { get; set; }
        = new List<LedgerPostingDetail>();

}