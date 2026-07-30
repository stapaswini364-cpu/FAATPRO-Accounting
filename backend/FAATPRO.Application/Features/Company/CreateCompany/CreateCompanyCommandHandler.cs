using MediatR;

namespace FAATPRO.Application.Features.Company.Commands.CreateCompany;


public class CreateCompanyCommandHandler 
    : IRequestHandler<CreateCompanyCommand, Guid>
{

    public async Task<Guid> Handle(
        CreateCompanyCommand request,
        CancellationToken cancellationToken)
    {


        // Later:
        // Save data using Repository
        // await _companyRepository.AddAsync(company);


        var companyId = Guid.NewGuid();


        return companyId;
    }
}