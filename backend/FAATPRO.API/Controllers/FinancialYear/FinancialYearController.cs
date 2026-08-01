using FAATPRO.Application.Features.FinancialYear.DTOs;
using FAATPRO.Application.Features.FinancialYear.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.FinancialYear;


[ApiController]
[Route("api/[controller]")]
public class FinancialYearController : ControllerBase
{

    private readonly IFinancialYearService _service;


    public FinancialYearController(
        IFinancialYearService service)
    {
        _service = service;
    }




    // GET: api/FinancialYear
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }





    // GET: api/FinancialYear/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _service.GetByIdAsync(id);


        if (result == null)
            return NotFound();


        return Ok(result);

    }





    // POST: api/FinancialYear
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateFinancialYearRequest request)
    {

        var result =
            await _service.CreateAsync(request);


        return Ok(new
        {
            Success = true,

            Message =
                "Financial Year created successfully.",

            Data = result
        });

    }





    // PUT: api/FinancialYear/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateFinancialYearRequest request)
    {

        var result =
            await _service.UpdateAsync(id, request);


        if (!result)
            return NotFound();


        return Ok(new
        {
            Success = true,

            Message =
                "Financial Year updated successfully."
        });

    }





    // DELETE: api/FinancialYear/{id}
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
            Success = true,

            Message =
                "Financial Year deleted successfully."
        });

    }

}