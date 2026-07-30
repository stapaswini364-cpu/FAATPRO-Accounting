namespace FAATPRO.Application.Features.Company.DTOs;

public class UpdateCompanyRequest : CreateCompanyRequest
{
    public Guid Id { get; set; }
}