using FAATPRO.Application.Features.Cities.DTOs;
using FAATPRO.Application.Features.Cities.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{

    private readonly ICityService _cityService;


    public CityController(
        ICityService cityService)
    {
        _cityService = cityService;
    }







    // GET: api/City

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var result =
            await _cityService.GetAllAsync();


        return Ok(result);

    }








    // GET: api/City/{id}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _cityService.GetByIdAsync(id);



        if(result == null)
            return NotFound();



        return Ok(result);

    }








    // POST: api/City

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCityRequest request)
    {

        var result =
            await _cityService.CreateAsync(request);



        return Ok(result);

    }








    // PUT: api/City/{id}

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateCityRequest request)
    {

        var result =
            await _cityService.UpdateAsync(
                id,
                request);



        if(!result)
            return NotFound();



        return Ok(new
        {
            message = "City updated successfully"
        });

    }








    // DELETE: api/City/{id}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _cityService.DeleteAsync(id);



        if(!result)
            return NotFound();



        return Ok(new
        {
            message = "City deleted successfully"
        });

    }

}