using FAATPRO.Application.Features.Countries.DTOs;
using FAATPRO.Application.Features.Countries.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{

    private readonly ICountryService _countryService;


    public CountryController(
        ICountryService countryService)
    {
        _countryService = countryService;
    }






    // GET: api/Country

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var result =
            await _countryService.GetAllAsync();


        return Ok(new
        {
            success = true,
            data = result
        });

    }








    // GET: api/Country/{id}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _countryService.GetByIdAsync(id);



        if (result == null)
        {
            return NotFound(new
            {
                success = false,
                message = "Country not found."
            });
        }



        return Ok(new
        {
            success = true,
            data = result
        });

    }








    // POST: api/Country

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCountryRequest request)
    {

        var result =
            await _countryService.CreateAsync(request);



        return Ok(new
        {
            success = true,
            message = "Country created successfully.",
            data = result
        });

    }








    // PUT: api/Country/{id}

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateCountryRequest request)
    {

        var result =
            await _countryService.UpdateAsync(
                id,
                request);



        if (!result)
        {
            return NotFound(new
            {
                success = false,
                message = "Country not found."
            });
        }



        return Ok(new
        {
            success = true,
            message = "Country updated successfully."
        });

    }








    // DELETE: api/Country/{id}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _countryService.DeleteAsync(id);



        if (!result)
        {
            return NotFound(new
            {
                success = false,
                message = "Country not found."
            });
        }



        return Ok(new
        {
            success = true,
            message = "Country deleted successfully."
        });

    }

}