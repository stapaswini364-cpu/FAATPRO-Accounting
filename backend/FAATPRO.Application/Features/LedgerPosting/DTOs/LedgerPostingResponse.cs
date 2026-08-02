namespace FAATPRO.Application.Features.LedgerPosting.DTOs;


public class LedgerPostingResponse
{

    public Guid Id { get; set; }


    public Guid LedgerId { get; set; }


    public string LedgerName { get; set; } = null!;


    public DateTime PostingDate { get; set; }


    public decimal Debit { get; set; }


    public decimal Credit { get; set; }


    public decimal Balance { get; set; }


    public string? Narration { get; set; }

}