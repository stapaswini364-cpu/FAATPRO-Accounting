namespace FAATPRO.Domain.Entities;

public class Branch
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public string BranchCode { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;


    public Company? Company { get; set; }
}