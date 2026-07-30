namespace FAATPRO.Application.Features.Countries.DTOs;


public class CountryResponse
{

    public Guid Id { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; }


    public DateTime CreatedAt { get; set; }

}