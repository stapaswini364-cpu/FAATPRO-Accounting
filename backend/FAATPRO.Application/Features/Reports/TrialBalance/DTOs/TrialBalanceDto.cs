namespace FAATPRO.Application.Features.Reports.TrialBalance.DTOs;


public class TrialBalanceDto
{

    public Guid LedgerId { get; set; }


    public string LedgerCode { get; set; } = null!;


    public string LedgerName { get; set; } = null!;



    public decimal OpeningBalance { get; set; }



    public decimal Debit { get; set; }



    public decimal Credit { get; set; }



    public decimal ClosingBalance { get; set; }



    public string BalanceType { get; set; } = null!;

}