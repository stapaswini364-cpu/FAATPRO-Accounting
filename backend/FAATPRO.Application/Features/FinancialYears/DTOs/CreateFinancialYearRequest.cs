namespace FAATPRO.Application.Features.FinancialYears.DTOs;

public class CreateFinancialYearRequest
{
    public Guid CompanyId { get; set; }

    public string YearName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }
}