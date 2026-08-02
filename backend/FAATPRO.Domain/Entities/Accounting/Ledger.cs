using FAATPRO.Domain.Common;
using FAATPRO.Domain.Enums;

namespace FAATPRO.Domain.Entities.Accounting;

public class Ledger : BaseEntity
{
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
    // Ledger Running Balance
    // ==========================

    public decimal CurrentBalance { get; set; }



    // ==========================
    // Contact Details
    // ==========================

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }



    // ==========================
    // Tax Details
    // ==========================

    public string? GSTIN { get; set; }



    // ==========================
    // Status
    // ==========================

    public bool IsActive { get; set; } = true;



    // ==========================
    // Audit Fields
    // ==========================

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }



    // ==========================
    // Navigation Properties
    // ==========================

    public AccountHead AccountHead { get; set; } = null!;

    public AccountGroup AccountGroup { get; set; } = null!;

    public AccountSubGroup? AccountSubGroup { get; set; }



    // ==========================
    // Journal Entry Relation
    // ==========================

    public ICollection<JournalEntryDetail> JournalEntryDetails { get; set; }
        = new List<JournalEntryDetail>();

}