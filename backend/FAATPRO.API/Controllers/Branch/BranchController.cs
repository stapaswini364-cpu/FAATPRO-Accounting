using FAATPRO.Application.Features.Branches.DTOs;
using FAATPRO.Application.Features.Branches.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.Branch;


[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{

    private readonly IBranchService _branchService;


    public BranchController(
        IBranchService branchService)
    {
        _branchService = branchService;
    }



    // GET: api/Branch
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _branchService.GetAllAsync();


        return Ok(result);
    }




    // GET: api/Branch/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _branchService.GetByIdAsync(id);


        if(result == null)
            return NotFound();


        return Ok(result);
    }




    // POST: api/Branch
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateBranchRequest request)
    {

        var result =
            await _branchService.CreateAsync(request);


        return Ok(new
        {
            Success = true,
            Message = "Branch created successfully.",
            Data = result
        });
    }




    // PUT: api/Branch/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateBranchRequest request)
    {

        var result =
            await _branchService.UpdateAsync(id, request);


        if(!result)
            return NotFound();


        return Ok(new
        {
            Success = true,
            Message = "Branch updated successfully."
        });
    }




    // DELETE: api/Branch/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _branchService.DeleteAsync(id);


        if(!result)
            return NotFound();


        return Ok(new
        {
            Success = true,
            Message = "Branch deleted successfully."
        });
    }

}