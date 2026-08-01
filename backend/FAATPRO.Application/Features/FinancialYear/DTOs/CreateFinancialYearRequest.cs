using System;

namespace FAATPRO.Application.Features.FinancialYear.DTOs;

public class CreateFinancialYearRequest
{
    public Guid CompanyId { get; set; }

    public string YearName { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }
}