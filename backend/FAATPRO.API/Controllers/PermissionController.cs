using FAATPRO.Application.Features.Permissions.DTOs;
using FAATPRO.Application.Features.Permissions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;


    public PermissionController(
        IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _permissionService.GetAllAsync();

        return Ok(result);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _permissionService.GetByIdAsync(id);


        if (result == null)
            return NotFound();


        return Ok(result);
    }



    [HttpPost]
    public async Task<IActionResult> Create(
        CreatePermissionRequest request)
    {
        var result =
            await _permissionService.CreateAsync(request);


        return Ok(result);
    }




    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreatePermissionRequest request)
    {
        var result =
            await _permissionService.UpdateAsync(
                id,
                request);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "Permission updated successfully"
        });
    }




    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result =
            await _permissionService.DeleteAsync(id);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "Permission deleted successfully"
        });
    }
}