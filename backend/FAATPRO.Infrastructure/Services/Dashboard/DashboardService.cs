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



    var today =
        DateTime.Today;



    var todaySales =
        await _context.JournalEntries

        .Where(x =>
            x.VoucherDate.Date == today)

        .SelectMany(x =>
            x.Details)

        .Where(x =>
            x.Ledger.Name.Contains("Sales"))

        .SumAsync(x =>
            x.Credit);




    var todayPurchase =
        await _context.JournalEntries

        .Where(x =>
            x.VoucherDate.Date == today)

        .SelectMany(x =>
            x.Details)

        .Where(x =>
            x.Ledger.Name.Contains("Purchase"))

        .SumAsync(x =>
            x.Debit);




    var grossProfit =
        revenue - expense;




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




    return new DashboardSummaryDto
    {

        TodaySales = todaySales,

        TodayPurchase = todayPurchase,

        GrossProfit = grossProfit,


        TotalRevenue = revenue,

        TotalExpense = expense,


        NetProfit =
            revenue - expense,


        CashBalance = cash,

        BankBalance = bank,


        TotalCustomers = customers,

        TotalVendors = 0,


        Receivable = 0,

        Payable = 0

    };

}

    // =====================================
    // Recent Transactions
    // =====================================

    public async Task<List<RecentTransactionDto>> GetRecentTransactionsAsync()
    {

        return await _context.JournalEntries

            .OrderByDescending(x =>
                x.VoucherDate)

            .Take(10)

            .Select(x => new RecentTransactionDto
            {

                VoucherNo = x.VoucherNo,

                Date = x.VoucherDate,

                Type = "Journal",

                Amount =
                    x.Details.Sum(d =>
                        d.Debit)

            })

            .ToListAsync();

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



        return new AccountSummaryDto
        {

            Cash = cash,

            Bank = bank,

            Receivable = 0,

            Payable = 0

        };

    }





    // =====================================
    // Revenue Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetRevenueChartAsync()
    {

        var raw =

            await _context.JournalEntries

            .SelectMany(
                e => e.Details,

                (e,d)=>new
                {
                    Year = e.VoucherDate.Year,

                    Month = e.VoucherDate.Month,

                    d.Credit,

                    LedgerName = d.Ledger.Name
                })

            .Where(x =>
                x.LedgerName.Contains("Sales"))

            .GroupBy(x=>new
            {
                x.Year,

                x.Month

            })

            .Select(x=>new
            {
                x.Key.Year,

                x.Key.Month,

                Amount =
                    x.Sum(y=>y.Credit)

            })

            .ToListAsync();



        return raw.Select(x=>new DashboardChartDto
        {

            Month =
                new DateTime(
                    x.Year,
                    x.Month,
                    1)

                .ToString("MMM"),


            Amount = x.Amount


        }).ToList();

    }





    // =====================================
    // Expense Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetExpenseChartAsync()
    {

        var raw =

            await _context.JournalEntries

            .SelectMany(
                e=>e.Details,

                (e,d)=>new
                {
                    Year = e.VoucherDate.Year,

                    Month = e.VoucherDate.Month,

                    d.Debit,

                    LedgerName = d.Ledger.Name

                })

            .Where(x=>
                x.LedgerName.Contains("Purchase"))

            .GroupBy(x=>new
            {
                x.Year,

                x.Month

            })

            .Select(x=>new
            {
                x.Key.Year,

                x.Key.Month,

                Amount =
                    x.Sum(y=>y.Debit)

            })

            .ToListAsync();



        return raw.Select(x=>new DashboardChartDto
        {

            Month =
                new DateTime(
                    x.Year,
                    x.Month,
                    1)

                .ToString("MMM"),


            Amount = x.Amount


        }).ToList();

    }





    // =====================================
    // Cash Flow Chart
    // =====================================

    public async Task<List<DashboardChartDto>> GetCashFlowChartAsync()
    {

        var raw =

            await _context.JournalEntries

            .SelectMany(
                e=>e.Details,

                (e,d)=>new
                {

                    Year = e.VoucherDate.Year,

                    Month = e.VoucherDate.Month,

                    LedgerName = d.Ledger.Name,

                    Debit = d.Debit,

                    Credit = d.Credit

                })

            .Where(x =>
                x.LedgerName.Contains("Cash")
                ||
                x.LedgerName.Contains("Bank"))

            .GroupBy(x=>new
            {
                x.Year,

                x.Month

            })

            .Select(x=>new
            {
                x.Key.Year,

                x.Key.Month,


                // FIXED CASH FLOW CALCULATION
                Amount =
                    x.Sum(y =>
                        y.Credit - y.Debit)

            })

            .OrderBy(x=>x.Year)

            .ThenBy(x=>x.Month)

            .ToListAsync();



        return raw.Select(x=>new DashboardChartDto
        {

            Month =
                new DateTime(
                    x.Year,
                    x.Month,
                    1)

                .ToString("MMM"),


            Amount = x.Amount


        }).ToList();

    }



}