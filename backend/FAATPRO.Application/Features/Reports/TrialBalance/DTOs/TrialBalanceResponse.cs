namespace FAATPRO.Application.Features.Reports.TrialBalance.DTOs;


public class TrialBalanceResponse
{

    public Guid LedgerId { get; set; }


    public string LedgerName { get; set; } = null!;


    public decimal OpeningBalance { get; set; }


    public decimal Debit { get; set; }


    public decimal Credit { get; set; }


    public decimal ClosingBalance { get; set; }

}