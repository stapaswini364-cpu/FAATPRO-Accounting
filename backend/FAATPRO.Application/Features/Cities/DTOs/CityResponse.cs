namespace FAATPRO.Application.Features.Cities.DTOs;


public class CityResponse
{

    public Guid Id { get; set; }


    public Guid StateId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; }


    public DateTime CreatedAt { get; set; }

}