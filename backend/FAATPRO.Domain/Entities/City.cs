namespace FAATPRO.Domain.Entities;


public class City
{

    public Guid Id { get; set; }


    public Guid StateId { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public State State { get; set; } = null!;

}