using FAATPRO.Domain.Enums;


namespace FAATPRO.Application.Features.AccountHeads.DTOs;


public class AccountHeadResponse
{

    public Guid Id { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public AccountNature Nature { get; set; }


    public int DisplayOrder { get; set; }


    public bool IsSystem { get; set; }


    public bool IsActive { get; set; }


    public DateTime CreatedOn { get; set; }

}