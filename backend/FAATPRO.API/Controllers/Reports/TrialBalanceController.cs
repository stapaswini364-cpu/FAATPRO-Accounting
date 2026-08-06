using FAATPRO.Application.Features.Reports.TrialBalance.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.Reports;


[ApiController]
[Route("api/[controller]")]
public class TrialBalanceController : ControllerBase
{

    private readonly ITrialBalanceService _service;


    public TrialBalanceController(
        ITrialBalanceService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var result =
            await _service.GetAsync();


        return Ok(result);

    }

}