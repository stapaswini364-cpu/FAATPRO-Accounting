namespace FAATPRO.Domain.Entities;


public class State
{

    public Guid Id { get; set; }


    public Guid CountryId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public Country Country { get; set; } = null!;

}