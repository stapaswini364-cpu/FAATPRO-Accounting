namespace FAATPRO.Domain.Entities;


public class Country
{

    public Guid Id { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public bool IsActive { get; set; } = true;


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public ICollection<State> States { get; set; }
        = new List<State>();

}