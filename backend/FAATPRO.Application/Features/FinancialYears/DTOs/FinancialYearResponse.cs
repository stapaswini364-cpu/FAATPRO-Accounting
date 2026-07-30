namespace FAATPRO.Application.Features.FinancialYears.DTOs;

public class FinancialYearResponse
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public string YearName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }
}