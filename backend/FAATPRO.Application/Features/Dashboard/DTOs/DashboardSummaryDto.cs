namespace FAATPRO.Application.Features.Dashboard.DTOs;

public class DashboardSummaryDto
{

    // =====================================
    // Sales & Purchase
    // =====================================

    public decimal TodaySales { get; set; }

    public decimal TodayPurchase { get; set; }


    public decimal TotalSales { get; set; }

    public decimal TotalPurchase { get; set; }



    // =====================================
    // Profit
    // =====================================

    public decimal GrossProfit { get; set; }

    public decimal NetProfit { get; set; }



    // =====================================
    // Cash & Bank
    // =====================================

    public decimal CashBalance { get; set; }

    public decimal BankBalance { get; set; }



    // =====================================
    // Party Balance
    // =====================================

    public int TotalCustomers { get; set; }

    public int TotalVendors { get; set; }


    public decimal Receivable { get; set; }

    public decimal Payable { get; set; }



    // =====================================
    // Existing Dashboard
    // =====================================

    public decimal TotalRevenue { get; set; }

    public decimal TotalExpense { get; set; }



    // =====================================
    // Extra ERP KPI
    // =====================================

    public decimal CashInHand { get; set; }

    public decimal CurrentBalance { get; set; }

}