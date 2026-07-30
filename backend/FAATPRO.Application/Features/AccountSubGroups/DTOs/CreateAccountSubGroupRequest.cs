using FAATPRO.Domain.Enums;

namespace FAATPRO.Application.Features.AccountSubGroups.DTOs;

public class CreateAccountSubGroupRequest
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public Guid AccountGroupId { get; set; }

    public AccountNature Nature { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;
}