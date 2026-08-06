namespace FAATPRO.Application.Features.Dashboard.DTOs;

public class DashboardSummaryDto
{

    // ===============================
    // Sales & Purchase
    // ===============================

    public decimal TodaySales { get; set; }


    public decimal TodayPurchase { get; set; }



    // ===============================
    // Profit
    // ===============================

    public decimal GrossProfit { get; set; }


    public decimal NetProfit { get; set; }



    // ===============================
    // Cash & Bank
    // ===============================

    public decimal CashBalance { get; set; }


    public decimal BankBalance { get; set; }



    // ===============================
    // Parties
    // ===============================

    public int TotalCustomers { get; set; }


    public int TotalVendors { get; set; }



    public decimal Receivable { get; set; }


    public decimal Payable { get; set; }



    // ===============================
    // Existing Reports
    // ===============================

    public decimal TotalRevenue { get; set; }


    public decimal TotalExpense { get; set; }


}