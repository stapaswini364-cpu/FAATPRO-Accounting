using FAATPRO.Application.Features.Users.DTOs;
using FAATPRO.Application.Features.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAATPRO.API.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(
        IUserService userService)
    {
        _userService = userService;
    }



    // GET: api/User
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }



    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var user = await _userService.GetByIdAsync(id);


        if (user == null)
            return NotFound();


        return Ok(user);
    }



    // POST: api/User
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserRequest request)
    {
        var result = await _userService.CreateAsync(request);

        return Ok(result);
    }



    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateUserRequest request)
    {
        var result = await _userService.UpdateAsync(
            id,
            request);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "User updated successfully"
        });
    }



    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var result = await _userService.DeleteAsync(id);


        if (!result)
            return NotFound();


        return Ok(new
        {
            message = "User deleted successfully"
        });
    }
}