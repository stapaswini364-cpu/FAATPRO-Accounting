using FAATPRO.Application.Features.Dashboard.DTOs;
using FAATPRO.Application.Features.Dashboard.Interfaces;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Dashboard;


public class DashboardService : IDashboardService
{

    private readonly ApplicationDbContext _context;


    public DashboardService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    // =====================================
    // Dashboard Summary
    // =====================================

    public async Task<DashboardSummaryDto> GetSummaryAsync()
    {

        var revenue =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.Name.Contains("Sales"))

            .SumAsync(x =>
                x.Credit);



        var expense =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.Name.Contains("Purchase"))

            .SumAsync(x =>
                x.Debit);



        var cash =
            await _context.Ledgers

            .Where(x =>
                x.Name.Contains("Cash"))

            .SumAsync(x =>
                x.OpeningBalance);



        var bank =
            await _context.Ledgers

            .Where(x =>
                x.Name.Contains("Bank"))

            .SumAsync(x =>
                x.OpeningBalance);



        var customers =
            await _context.Customers

            .CountAsync();



        var vendors = 0;


        decimal receivable = 0;

        decimal payable = 0;



        return new DashboardSummaryDto
        {

            TotalRevenue = revenue,

            TotalExpense = expense,

            NetProfit = revenue - expense,

            CashBalance = cash,

            BankBalance = bank,

            TotalCustomers = customers,

            TotalVendors = vendors,

            Receivable = receivable,

            Payable = payable

        };

    }





    // =====================================
    // Recent Transactions
    // =====================================

    public async Task<List<RecentTransactionDto>> GetRecentTransactionsAsync()
    {

        var transactions =

            await _context.JournalEntries

            .OrderByDescending(x =>
                x.VoucherDate)

            .Take(10)

            .Select(x => new RecentTransactionDto
            {

                VoucherNo =
                    x.VoucherNo,


                Date =
                    x.VoucherDate,


                Type =
                    "Journal",


                Amount =
                    x.Details

                    .Sum(d =>
                        d.Debit)

            })

            .ToListAsync();



        return transactions;

    }





    // =====================================
    // Account Summary
    // =====================================

    public async Task<AccountSummaryDto> GetAccountSummaryAsync()
    {

        var cash =
            await _context.Ledgers

            .Where(x =>
                x.Name.Contains("Cash"))

            .SumAsync(x =>
                x.OpeningBalance);



        var bank =
            await _context.Ledgers

            .Where(x =>
                x.Name.Contains("Bank"))

            .SumAsync(x =>
                x.OpeningBalance);



        decimal receivable = 0;

        decimal payable = 0;



        return new AccountSummaryDto
        {

            Cash = cash,

            Bank = bank,

            Receivable = receivable,

            Payable = payable

        };

    }





    // =====================================
    // Revenue Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetRevenueChartAsync()
    {

        var data =

            await _context.JournalEntries

            .SelectMany(
                entry => entry.Details,

                (entry, detail) => new
                {
                    Date = entry.VoucherDate,

                    Credit = detail.Credit,

                    LedgerName = detail.Ledger.Name
                })


            .Where(x =>
                x.LedgerName.Contains("Sales"))


            .GroupBy(x => new
            {
                x.Date.Year,

                x.Date.Month
            })


            .Select(x => new DashboardChartDto
            {

                Month =
                    new DateTime(
                        x.Key.Year,
                        x.Key.Month,
                        1)

                    .ToString("MMM"),


                Amount =
                    x.Sum(y =>
                        y.Credit)

            })


            .ToListAsync();



        return data;

    }





    // =====================================
    // Expense Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetExpenseChartAsync()
    {

        var data =

            await _context.JournalEntries

            .SelectMany(
                entry => entry.Details,

                (entry, detail) => new
                {
                    Date = entry.VoucherDate,

                    Debit = detail.Debit,

                    LedgerName = detail.Ledger.Name
                })


            .Where(x =>
                x.LedgerName.Contains("Purchase"))


            .GroupBy(x => new
            {
                x.Date.Year,

                x.Date.Month
            })


            .Select(x => new DashboardChartDto
            {

                Month =
                    new DateTime(
                        x.Key.Year,
                        x.Key.Month,
                        1)

                    .ToString("MMM"),


                Amount =
                    x.Sum(y =>
                        y.Debit)

            })


            .ToListAsync();



        return data;

    }





    // =====================================
    // Cash Flow Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetCashFlowChartAsync()
    {

        var data =

            await _context.JournalEntries

            .SelectMany(
                entry => entry.Details,

                (entry, detail) => new
                {
                    Date = entry.VoucherDate,

                    Debit = detail.Debit,

                    Credit = detail.Credit
                })


            .GroupBy(x => new
            {
                x.Date.Year,

                x.Date.Month
            })


            .Select(x => new DashboardChartDto
            {

                Month =
                    new DateTime(
                        x.Key.Year,
                        x.Key.Month,
                        1)

                    .ToString("MMM"),


                Amount =
                    x.Sum(y =>
                        y.Credit - y.Debit)

            })


            .OrderBy(x =>
                x.Month)


            .ToListAsync();



        return data;

    }



}