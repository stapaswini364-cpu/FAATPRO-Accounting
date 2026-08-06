using FAATPRO.Domain.Common;

namespace FAATPRO.Domain.Entities.Accounting;

public class VoucherType : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;
}