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


        // Revenue = Income Head Credit

        var revenue =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountHead.Code == "INC")

            .SumAsync(x =>
                x.Credit);



        // Expense = Expense Head Debit

        var expense =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountHead.Code == "EXP")

            .SumAsync(x =>
                x.Debit);



        // Cash Balance

        var cashBalance =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountGroup.Code == "1120")

            .SumAsync(x =>
                x.Debit - x.Credit);



        // Bank Balance

        var bankBalance =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountGroup.Code == "1110")

            .SumAsync(x =>
                x.Debit - x.Credit);



        var customers =
            await _context.Customers
            .CountAsync();



        return new DashboardSummaryDto
        {

            TotalRevenue =
                revenue,


            TotalExpense =
                expense,


            NetProfit =
                revenue - expense,


            CashBalance =
                cashBalance,


            BankBalance =
                bankBalance,


            TotalCustomers =
                customers,


            TotalVendors = 0,


            Receivable = 0,


            Payable = 0,


            TodaySales = 0,


            TodayPurchase = 0,


            GrossProfit =
                revenue - expense

        };


    }





    // =====================================
    // Recent Transactions
    // =====================================


    public async Task<List<RecentTransactionDto>>
        GetRecentTransactionsAsync()
    {


        return await _context.JournalEntries

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
                    x.Details.Sum(d =>
                        d.Debit)

            })

            .ToListAsync();

    }







    // =====================================
    // Account Summary
    // =====================================


    public async Task<AccountSummaryDto>
        GetAccountSummaryAsync()
    {


        var cash =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountGroup.Code == "1120")

            .SumAsync(x =>
                x.Debit - x.Credit);




        var bank =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountGroup.Code == "1110")

            .SumAsync(x =>
                x.Debit - x.Credit);



        return new AccountSummaryDto
        {

            Cash =
                cash,


            Bank =
                bank,


            Receivable = 0,


            Payable = 0

        };


    }







    // =====================================
    // Revenue Chart
    // =====================================


    public async Task<List<DashboardChartDto>>
        GetRevenueChartAsync()
    {


        var data =
            await _context.LedgerPostings

            .Where(x =>
                x.Ledger.AccountHead.Code == "INC")


            .GroupBy(x => new
            {

                x.PostingDate.Year,

                x.PostingDate.Month

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


    public async Task<List<DashboardChartDto>>
        GetExpenseChartAsync()
    {


        return await _context.LedgerPostings

        .Where(x =>
            x.Ledger.AccountHead.Code == "EXP")


        .GroupBy(x => new
        {

            x.PostingDate.Year,

            x.PostingDate.Month

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


    }







    // =====================================
    // Cash Flow Chart
    // =====================================


    public async Task<List<DashboardChartDto>>
        GetCashFlowChartAsync()
    {


        return await _context.LedgerPostings


        .Where(x =>
            x.Ledger.AccountGroup.Code == "1110"
            ||
            x.Ledger.AccountGroup.Code == "1120")


        .GroupBy(x=>new
        {

            x.PostingDate.Year,

            x.PostingDate.Month

        })


        .Select(x=>new DashboardChartDto
        {

            Month =
                new DateTime(
                    x.Key.Year,
                    x.Key.Month,
                    1)

                .ToString("MMM"),


            Amount =
                x.Sum(y =>
                    y.Debit -
                    y.Credit)

        })


        .ToListAsync();


    }


}