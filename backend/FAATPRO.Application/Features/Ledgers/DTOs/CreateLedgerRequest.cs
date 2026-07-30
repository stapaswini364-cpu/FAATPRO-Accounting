using FAATPRO.Domain.Enums;

namespace FAATPRO.Application.Features.Ledgers.DTOs;

public class CreateLedgerRequest
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;


    // Account Hierarchy

    public Guid AccountHeadId { get; set; }

    public Guid AccountGroupId { get; set; }

    public Guid? AccountSubGroupId { get; set; }



    // Opening Balance

    public decimal OpeningBalance { get; set; }

    public BalanceType BalanceType { get; set; }



    // Contact Details

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }



    // Tax

    public string? GSTIN { get; set; }



    public bool IsActive { get; set; } = true;
}