namespace FAATPRO.Application.Features.Cities.DTOs;


public class CreateCityRequest
{

    public Guid StateId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;

}