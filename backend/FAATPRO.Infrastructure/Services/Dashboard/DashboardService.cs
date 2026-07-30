using FAATPRO.Application.Features.Dashboard.DTOs;
using FAATPRO.Application.Features.Dashboard.Interfaces;

namespace FAATPRO.Infrastructure.Services.Dashboard;

public class DashboardService : IDashboardService
{
    public DashboardService()
    {
    }


    public async Task<DashboardSummaryDto> GetSummaryAsync()
    {
        return new DashboardSummaryDto
        {
            TotalRevenue = 0,

            TotalExpense = 0,

            NetProfit = 0,

            CashBalance = 0,

            BankBalance = 0,

            TotalCustomers = 0,

            TotalVendors = 0
        };
    }
}