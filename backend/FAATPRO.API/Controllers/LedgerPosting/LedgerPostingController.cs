using FAATPRO.Application.Features.LedgerPosting.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.LedgerPosting;


[ApiController]
[Route("api/[controller]")]
public class LedgerPostingController : ControllerBase
{

    private readonly ILedgerPostingService _ledgerPostingService;


    public LedgerPostingController(
        ILedgerPostingService ledgerPostingService)
    {
        _ledgerPostingService = ledgerPostingService;
    }



    // ==========================================
    // Ledger Statement
    // ==========================================

    // GET:
    // api/LedgerPosting/statement/{ledgerId}

    [HttpGet("statement/{ledgerId}")]
    public async Task<IActionResult> GetLedgerStatement(
        Guid ledgerId)
    {

        var result =
            await _ledgerPostingService
            .GetLedgerStatementAsync(
                ledgerId
            );


        return Ok(result);

    }

}