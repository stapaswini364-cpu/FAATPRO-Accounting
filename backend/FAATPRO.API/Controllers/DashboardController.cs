using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using FAATPRO.Application.Features.Dashboard.Interfaces;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{

    private readonly IDashboardService _dashboardService;


    public DashboardController(
        IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }



    // ==========================================
    // Dashboard Summary
    // ==========================================

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var result =
            await _dashboardService.GetSummaryAsync();

        return Ok(result);
    }



    // ==========================================
    // Recent Transactions
    // ==========================================

    [HttpGet("recent-transactions")]
    public async Task<IActionResult> GetRecentTransactions()
    {
        var result =
            await _dashboardService.GetRecentTransactionsAsync();

        return Ok(result);
    }



    // ==========================================
    // Account Summary
    // ==========================================

    [HttpGet("account-summary")]
    public async Task<IActionResult> GetAccountSummary()
    {
        var result =
            await _dashboardService.GetAccountSummaryAsync();

        return Ok(result);
    }



    // ==========================================
    // Revenue Chart
    // ==========================================

    [HttpGet("revenue-chart")]
    public async Task<IActionResult> GetRevenueChart()
    {
        var result =
            await _dashboardService.GetRevenueChartAsync();

        return Ok(result);
    }



    // ==========================================
    // Expense Chart
    // ==========================================

    [HttpGet("expense-chart")]
    public async Task<IActionResult> GetExpenseChart()
    {
        var result =
            await _dashboardService.GetExpenseChartAsync();

        return Ok(result);
    }



    // ==========================================
    // Cash Flow Chart
    // ==========================================

    [HttpGet("cash-flow-chart")]
    public async Task<IActionResult> GetCashFlowChart()
    {
        var result =
            await _dashboardService.GetCashFlowChartAsync();

        return Ok(result);
    }

}