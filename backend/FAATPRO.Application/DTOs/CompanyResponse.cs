namespace FAATPRO.Application.Features.Company.DTOs;

public class CompanyResponse
{
    public Guid Id { get; set; }

    public string CompanyCode { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public string GSTNumber { get; set; } = string.Empty;

    public string PANNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}