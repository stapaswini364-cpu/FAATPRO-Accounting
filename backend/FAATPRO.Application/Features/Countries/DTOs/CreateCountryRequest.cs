namespace FAATPRO.Application.Features.Countries.DTOs;


public class CreateCountryRequest
{

    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;

}