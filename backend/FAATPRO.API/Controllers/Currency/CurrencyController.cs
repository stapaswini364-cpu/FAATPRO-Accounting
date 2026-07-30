using FAATPRO.Application.Features.Currencies.DTOs;
using FAATPRO.Application.Features.Currencies.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{

    private readonly ICurrencyService _service;


    public CurrencyController(
        ICurrencyService service)
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
        CreateCurrencyRequest request)
    {

        var result =
            await _service.CreateAsync(request);


        return Ok(new
        {
            Success = true,
            Message = "Currency created successfully.",
            Data = result
        });

    }






    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateCurrencyRequest request)
    {

        var result =
            await _service.UpdateAsync(id, request);


        if(!result)
            return NotFound();


        return Ok(new
        {
            Success = true,
            Message = "Currency updated successfully."
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
            Message = "Currency deleted successfully."
        });

    }

}