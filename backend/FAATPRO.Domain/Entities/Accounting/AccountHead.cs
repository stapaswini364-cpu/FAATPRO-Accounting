using System.ComponentModel.DataAnnotations;
using FAATPRO.Domain.Common;
using FAATPRO.Domain.Enums;

namespace FAATPRO.Domain.Entities.Accounting;

public class AccountHead : BaseEntity
{

    [Required]
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;


    [Required]
    public AccountNature Nature { get; set; }


    public int DisplayOrder { get; set; }


    public bool IsSystem { get; set; } = false;


    public bool IsActive { get; set; } = true;


    public DateTime CreatedOn { get; set; }


    public Guid? CreatedBy { get; set; }


    public DateTime? ModifiedOn { get; set; }


    public Guid? ModifiedBy { get; set; }



    // Navigation
    public ICollection<AccountGroup> AccountGroups { get; set; }
        = new List<AccountGroup>();

}