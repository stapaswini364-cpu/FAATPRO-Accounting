using FAATPRO.Application.Features.Dashboard.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers.Dashboard;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;

    public DashboardController(
        IDashboardService service)
    {
        _service = service;
    }


    [HttpGet("summary")]
    public async Task<IActionResult> Summary()
    {
        var result = await _service.GetSummaryAsync();

        return Ok(new
        {
            success = true,
            data = result
        });
    }
}