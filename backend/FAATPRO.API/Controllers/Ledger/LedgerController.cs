using FAATPRO.Application.Features.Ledgers.DTOs;
using FAATPRO.Application.Features.Ledgers.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.Ledger;


[ApiController]
[Route("api/[controller]")]
public class LedgerController : ControllerBase
{

    private readonly ILedgerService _service;


    public LedgerController(
        ILedgerService service)
    {
        _service = service;
    }



    // GET: api/Ledger
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }




    // GET: api/Ledger/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);


        if (result == null)
            return NotFound();


        return Ok(result);
    }




    // POST: api/Ledger
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateLedgerRequest request)
    {

        var result =
            await _service.CreateAsync(request);


        return Ok(result);
    }





    // PUT: api/Ledger/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateLedgerRequest request)
    {

        var result =
            await _service.UpdateAsync(id, request);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "Ledger updated successfully"
        });
    }






    // DELETE: api/Ledger/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _service.DeleteAsync(id);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "Ledger deleted successfully"
        });
    }

}