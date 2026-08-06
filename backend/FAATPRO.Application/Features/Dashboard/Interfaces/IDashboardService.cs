using FAATPRO.Application.Features.Dashboard.DTOs;


namespace FAATPRO.Application.Features.Dashboard.Interfaces;


public interface IDashboardService
{

    // Dashboard KPI Summary
    Task<DashboardSummaryDto> GetSummaryAsync();



    // Recent Transactions
    Task<List<RecentTransactionDto>> GetRecentTransactionsAsync();



    // Account Summary
    Task<AccountSummaryDto> GetAccountSummaryAsync();



    // Revenue Chart
    Task<List<DashboardChartDto>> GetRevenueChartAsync();



    // Expense Chart
    Task<List<DashboardChartDto>> GetExpenseChartAsync();
// Cash Flow Chart

Task<List<DashboardChartDto>> GetCashFlowChartAsync();

}