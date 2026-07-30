using FAATPRO.Application.Features.Roles.DTOs;
using FAATPRO.Application.Features.Roles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }


    // GET ALL ROLES
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetAllAsync();

        return Ok(result);
    }


    // GET ROLE BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _roleService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }


    // CREATE ROLE
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateRoleRequest request)
    {
        var result = await _roleService.CreateAsync(request);

        return Ok(result);
    }


    // UPDATE ROLE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateRoleRequest request)
    {
        var result = await _roleService.UpdateAsync(id, request);

        if (!result)
            return NotFound();

        return Ok(new
        {
            message = "Role updated successfully"
        });
    }


    // DELETE ROLE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _roleService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return Ok(new
        {
            message = "Role deleted successfully"
        });
    }
}