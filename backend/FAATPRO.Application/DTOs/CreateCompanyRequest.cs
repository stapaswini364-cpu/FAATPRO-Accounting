namespace FAATPRO.Application.Features.Company.DTOs;

public class CreateCompanyRequest
{
    public string CompanyCode { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public string LegalName { get; set; } = string.Empty;

    public string GSTNumber { get; set; } = string.Empty;

    public string PANNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string AddressLine1 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;
}