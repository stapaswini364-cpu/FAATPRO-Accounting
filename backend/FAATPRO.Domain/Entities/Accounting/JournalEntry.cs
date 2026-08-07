using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;

public class JournalEntry : BaseEntity
{
    public string VoucherNo { get; set; } = null!;

    public DateTime VoucherDate { get; set; }

    public string? ReferenceNo { get; set; }

    public string? Narration { get; set; }



    // ===============================
    // Voucher Type
    // ===============================

    public Guid? VoucherTypeId { get; set; }

    public VoucherType? VoucherType { get; set; }



    // ===============================
    // Amount
    // ===============================

    public decimal TotalDebit { get; set; }

    public decimal TotalCredit { get; set; }



    // ===============================
    // Company
    // ===============================

    public Guid CompanyId { get; set; }

    public Guid FinancialYearId { get; set; }



    // ===============================
    // Audit
    // ===============================

    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }



    // ===============================
    // Details
    // ===============================

    public ICollection<JournalEntryDetail> Details { get; set; }
        = new List<JournalEntryDetail>();

}