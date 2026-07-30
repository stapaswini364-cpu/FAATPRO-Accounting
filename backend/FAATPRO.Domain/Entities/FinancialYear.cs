using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities;

public class FinancialYear : AuditableEntity
{
    public Guid CompanyId { get; set; }

    public string YearName { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }

    public bool IsClosed { get; set; }

    public Company? Company { get; set; }
}