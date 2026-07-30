using FAATPRO.Application.Features.States.DTOs;
using FAATPRO.Application.Features.States.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StateController : ControllerBase
{

    private readonly IStateService _stateService;


    public StateController(
        IStateService stateService)
    {
        _stateService = stateService;
    }




    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _stateService.GetAllAsync();

        return Ok(result);
    }






    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _stateService.GetByIdAsync(id);


        if(result == null)
            return NotFound();


        return Ok(result);
    }







    [HttpPost]
    public async Task<IActionResult> Create(
        CreateStateRequest request)
    {

        var result =
            await _stateService.CreateAsync(request);


        return Ok(result);
    }







    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateStateRequest request)
    {

        var result =
            await _stateService.UpdateAsync(
                id,
                request);



        if(!result)
            return NotFound();


        return Ok(
            new
            {
                message = "State updated successfully"
            });
    }








    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _stateService.DeleteAsync(id);



        if(!result)
            return NotFound();



        return Ok(
            new
            {
                message = "State deleted successfully"
            });
    }

}