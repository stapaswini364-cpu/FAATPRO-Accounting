namespace FAATPRO.Application.Features.Dashboard.DTOs;

public class RecentTransactionDto
{
    public string VoucherNo { get; set; } = "";

    public DateTime Date { get; set; }

    public string Type { get; set; } = "";

    public decimal Amount { get; set; }
}