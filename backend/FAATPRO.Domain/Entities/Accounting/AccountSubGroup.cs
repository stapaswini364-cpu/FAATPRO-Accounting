using FAATPRO.Domain.Common;
using FAATPRO.Domain.Enums;

namespace FAATPRO.Domain.Entities.Accounting;

public class AccountSubGroup : BaseEntity
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;


    public Guid AccountGroupId { get; set; }


    public AccountNature Nature { get; set; }


    public int DisplayOrder { get; set; }


    public bool IsActive { get; set; } = true;


    public DateTime CreatedOn { get; set; }


    public Guid? CreatedBy { get; set; }


    public DateTime? ModifiedOn { get; set; }


    public Guid? ModifiedBy { get; set; }



    // Navigation

    public AccountGroup AccountGroup { get; set; } = null!;
}