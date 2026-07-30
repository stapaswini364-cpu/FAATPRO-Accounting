namespace FAATPRO.Application.Features.States.DTOs;


public class CreateStateRequest
{

    public Guid CountryId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;

}