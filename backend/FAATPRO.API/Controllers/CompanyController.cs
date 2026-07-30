using FAATPRO.Application.Features.Companies.DTOs;
using FAATPRO.Application.Features.Companies.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{

    private readonly ICompanyService _companyService;


    public CompanyController(
        ICompanyService companyService)
    {
        _companyService = companyService;
    }



    // ==========================
    // GET ALL COMPANIES
    // ==========================

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies =
            await _companyService.GetAllAsync();


        return Ok(companies);
    }




    // ==========================
    // GET COMPANY BY ID
    // ==========================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var company =
            await _companyService.GetByIdAsync(id);


        if(company == null)
            return NotFound(new
            {
                Message = "Company not found."
            });


        return Ok(company);
    }




    // ==========================
    // CREATE COMPANY
    // ==========================

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCompanyRequest request)
    {

        var company =
            await _companyService.CreateAsync(request);



        return Ok(new
        {
            Success = true,

            Message =
                "Company created successfully.",

            Data = company
        });

    }





    // ==========================
    // UPDATE COMPANY
    // ==========================

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        CreateCompanyRequest request)
    {

        var result =
            await _companyService.UpdateAsync(
                id,
                request);



        if(!result)
            return NotFound(new
            {
                Message = "Company not found."
            });



        return Ok(new
        {
            Success = true,

            Message =
                "Company updated successfully."
        });

    }





    // ==========================
    // DELETE COMPANY
    // ==========================

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {

        var result =
            await _companyService.DeleteAsync(id);



        if(!result)
            return NotFound(new
            {
                Message = "Company not found."
            });



        return Ok(new
        {
            Success = true,

            Message =
                "Company deleted successfully."
        });

    }

}