namespace FAATPRO.Application.Features.States.DTOs;


public class StateResponse
{

    public Guid Id { get; set; }


    public Guid CountryId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; }


    public DateTime CreatedAt { get; set; }

}