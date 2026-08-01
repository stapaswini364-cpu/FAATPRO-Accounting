using FAATPRO.Domain.Enums;

namespace FAATPRO.Application.Features.AccountGroups.DTOs;

public class AccountGroupResponse
{
    public Guid Id { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    // Parent Account Head
    public Guid AccountHeadId { get; set; }


    public string AccountHeadName { get; set; } = null!;


    public AccountNature Nature { get; set; }


    public int DisplayOrder { get; set; }


    public bool IsSystem { get; set; }


    public bool IsActive { get; set; }


    public DateTime CreatedOn { get; set; }
}