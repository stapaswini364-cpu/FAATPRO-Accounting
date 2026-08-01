using FAATPRO.Domain.Common;
using FAATPRO.Domain.Enums;

namespace FAATPRO.Domain.Entities.Accounting;

public class AccountGroup : BaseEntity
{
    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    // Foreign Key
    public Guid AccountHeadId { get; set; }


    public AccountNature Nature { get; set; }


    public int DisplayOrder { get; set; }


    public bool IsSystem { get; set; }


    public bool IsActive { get; set; } = true;


    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


    public Guid? CreatedBy { get; set; }


    public DateTime? ModifiedOn { get; set; }


    public Guid? ModifiedBy { get; set; }



    // Navigation
    public AccountHead AccountHead { get; set; } = null!;
}