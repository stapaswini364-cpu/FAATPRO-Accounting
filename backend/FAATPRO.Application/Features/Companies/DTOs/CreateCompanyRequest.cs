namespace FAATPRO.Application.Features.Companies.DTOs;

public class CreateCompanyRequest
{
    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? LegalName { get; set; }


    public string? GSTNumber { get; set; }

    public string? PANNumber { get; set; }

    public string? CINNumber { get; set; }


    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }


    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }


    public string? CurrencyCode { get; set; }

    public int? FinancialYearStartMonth { get; set; }
}