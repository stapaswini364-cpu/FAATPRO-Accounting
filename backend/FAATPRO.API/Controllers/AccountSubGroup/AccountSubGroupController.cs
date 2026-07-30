using FAATPRO.Application.Features.AccountSubGroups.DTOs;
using FAATPRO.Application.Features.AccountSubGroups.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.AccountSubGroup;


[ApiController]
[Route("api/[controller]")]
public class AccountSubGroupController : ControllerBase
{

    private readonly IAccountSubGroupService _service;


    public AccountSubGroupController(
        IAccountSubGroupService service)
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
        CreateAccountSubGroupRequest request)
    {
        var result =
            await _service.CreateAsync(request);


        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateAccountSubGroupRequest request)
    {

        var result =
            await _service.UpdateAsync(id, request);


        if(!result)
            return NotFound();


        return Ok(new
        {
            message = "Account Sub Group Updated"
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
            message = "Account Sub Group Deleted"
        });

    }

}