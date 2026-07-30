using FAATPRO.Application.Features.AccountGroups.DTOs;
using FAATPRO.Application.Features.AccountGroups.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.AccountGroup;


[ApiController]
[Route("api/[controller]")]
public class AccountGroupController : ControllerBase
{

    private readonly IAccountGroupService _service;


    public AccountGroupController(
        IAccountGroupService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();

        return Ok(data);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var data = await _service.GetByIdAsync(id);

        if(data == null)
            return NotFound();

        return Ok(data);
    }




    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAccountGroupRequest request)
    {
        var result =
            await _service.CreateAsync(request);

        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateAccountGroupRequest request)
    {
        var result =
            await _service.UpdateAsync(id, request);


        if(!result)
            return NotFound();


        return Ok(new
        {
            message = "Account Group Updated"
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
            message = "Account Group Deleted"
        });
    }

}