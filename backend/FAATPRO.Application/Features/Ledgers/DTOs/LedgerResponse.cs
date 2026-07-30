using FAATPRO.Domain.Enums;

namespace FAATPRO.Application.Features.Ledgers.DTOs;

public class LedgerResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;


    public Guid AccountHeadId { get; set; }

    public Guid AccountGroupId { get; set; }

    public Guid? AccountSubGroupId { get; set; }


    public decimal OpeningBalance { get; set; }

    public BalanceType BalanceType { get; set; }


    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? GSTIN { get; set; }


    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }
}