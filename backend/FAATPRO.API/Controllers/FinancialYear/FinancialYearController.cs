using FAATPRO.Application.Features.FinancialYears.DTOs;
using FAATPRO.Application.Features.FinancialYears.Interfaces;

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





    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }





    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var result =
            await _service.GetByIdAsync(id);


        if(result == null)
            return NotFound();


        return Ok(result);
    }





    [HttpPost]
    public async Task<IActionResult> Create(
        CreateFinancialYearRequest request)
    {

        var result =
            await _service.CreateAsync(request);


        return Ok(new
        {
            Success = true,
            Message = "Financial Year created successfully.",
            Data = result
        });
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateFinancialYearRequest request)
    {

        var result =
            await _service.UpdateAsync(id, request);


        if(!result)
            return NotFound();


        return Ok(new
        {
            Success = true,
            Message = "Financial Year updated successfully."
        });
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _service.DeleteAsync(id);


        if(!result)
            return NotFound();


        return Ok(new
        {
            Success = true,
            Message = "Financial Year deleted successfully."
        });
    }

}