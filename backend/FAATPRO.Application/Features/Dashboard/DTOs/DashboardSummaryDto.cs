namespace FAATPRO.Application.Features.Dashboard.DTOs;

public class DashboardSummaryDto
{
    public decimal TotalRevenue { get; set; }

    public decimal TotalExpense { get; set; }

    public decimal NetProfit { get; set; }

    public decimal CashBalance { get; set; }

    public decimal BankBalance { get; set; }

    public int TotalCustomers { get; set; }

    public int TotalVendors { get; set; }
}