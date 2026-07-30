using FAATPRO.Application.Features.AccountHeads.DTOs;
using FAATPRO.Application.Features.AccountHeads.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountHeadController : ControllerBase
{

    private readonly IAccountHeadService _accountHeadService;


    public AccountHeadController(
        IAccountHeadService accountHeadService)
    {
        _accountHeadService = accountHeadService;
    }







    // GET: api/AccountHead

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var result =
            await _accountHeadService.GetAllAsync();


        return Ok(result);

    }








    // GET: api/AccountHead/{id}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _accountHeadService.GetByIdAsync(id);



        if(result == null)
            return NotFound();



        return Ok(result);

    }









    // POST: api/AccountHead

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAccountHeadRequest request)
    {

        var result =
            await _accountHeadService.CreateAsync(request);



        return Ok(result);

    }









    // PUT: api/AccountHead/{id}

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateAccountHeadRequest request)
    {

        var result =
            await _accountHeadService.UpdateAsync(
                id,
                request);



        if(!result)
            return NotFound();



        return Ok(new
        {
            message = "Account Head updated successfully"
        });

    }









    // DELETE: api/AccountHead/{id}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _accountHeadService.DeleteAsync(id);



        if(!result)
            return NotFound();



        return Ok(new
        {
            message = "Account Head deleted successfully"
        });

    }

}