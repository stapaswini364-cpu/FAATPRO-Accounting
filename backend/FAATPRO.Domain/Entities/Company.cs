namespace FAATPRO.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }


    // Basic Information

    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? LegalName { get; set; }



    // Tax Information

    public string? GSTNumber { get; set; }

    public string? PANNumber { get; set; }

    public string? CINNumber { get; set; }



    // Contact

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }



    // Address

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }



    // Accounting Setup

    public string? CurrencyCode { get; set; }

    public int? FinancialYearStartMonth { get; set; }



    public bool IsActive { get; set; } = true;


    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}