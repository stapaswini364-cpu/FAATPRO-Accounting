namespace FAATPRO.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = "System";

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;
}