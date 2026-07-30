using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;

public class JournalEntry : BaseEntity
{
    public string VoucherNo { get; set; } = null!;

    public DateTime VoucherDate { get; set; }

    public string? ReferenceNo { get; set; }

    public string? Narration { get; set; }


    public decimal TotalDebit { get; set; }

    public decimal TotalCredit { get; set; }


    public Guid CompanyId { get; set; }

    public Guid FinancialYearId { get; set; }


    public DateTime CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }


    public ICollection<JournalEntryDetail> Details { get; set; }
        = new List<JournalEntryDetail>();
}