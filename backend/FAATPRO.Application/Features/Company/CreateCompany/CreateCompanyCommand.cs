using MediatR;

namespace FAATPRO.Application.Features.Company.Commands.CreateCompany;


public class CreateCompanyCommand : IRequest<Guid>
{
    public string CompanyName { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public string Phone { get; set; } = string.Empty;


    public string Address { get; set; } = string.Empty;


    public string GSTNumber { get; set; } = string.Empty;


    public string Country { get; set; } = string.Empty;


    public string State { get; set; } = string.Empty;


    public string City { get; set; } = string.Empty;
}