using FAATPRO.Application.Features.RolePermissions.DTOs;
using FAATPRO.Application.Features.RolePermissions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers.RolePermission;

[ApiController]
[Route("api/[controller]")]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _service;


    public RolePermissionController(
        IRolePermissionService service)
    {
        _service = service;
    }



    // GET: api/RolePermission/{roleId}

    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetByRoleId(
        Guid roleId)
    {
        var result =
            await _service.GetByRoleIdAsync(roleId);


        if (result == null)
            return NotFound();


        return Ok(result);
    }




    // POST: api/RolePermission/assign

    [HttpPost("assign")]
    public async Task<IActionResult> Assign(
        AssignPermissionRequest request)
    {
        var result =
            await _service.AssignPermissionAsync(request);


        if (!result)
            return BadRequest(
                "Permission already assigned.");


        return Ok(
            new
            {
                message = "Permission assigned successfully."
            });
    }




    // DELETE: api/RolePermission/{roleId}/{permissionId}

    [HttpDelete("{roleId}/{permissionId}")]
    public async Task<IActionResult> Remove(
        Guid roleId,
        Guid permissionId)
    {
        var result =
            await _service.RemovePermissionAsync(
                roleId,
                permissionId);


        if (!result)
            return NotFound();


        return Ok(
            new
            {
                message = "Permission removed successfully."
            });
    }
}