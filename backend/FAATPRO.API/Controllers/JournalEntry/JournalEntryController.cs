using FAATPRO.Application.Features.JournalEntries.DTOs;
using FAATPRO.Application.Features.JournalEntries.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace FAATPRO.API.Controllers.JournalEntry;


[ApiController]
[Route("api/[controller]")]
public class JournalEntryController : ControllerBase
{

    private readonly IJournalEntryService _service;


    public JournalEntryController(
        IJournalEntryService service)
    {
        _service = service;
    }




    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var result =
            await _service.GetAllAsync();


        return Ok(result);

    }





    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {

        var result =
            await _service.GetByIdAsync(id);


        if(result == null)
            return NotFound();


        return Ok(result);

    }






    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateJournalEntryRequest request)
    {

        try
        {

            Console.WriteLine(
                "Journal Entry Create Started"
            );


            var result =
                await _service.CreateAsync(request);



            Console.WriteLine(
                "Journal Entry Created Successfully"
            );


            return Ok(result);

        }
        catch(Exception ex)
        {

            Console.WriteLine(
                "========== JOURNAL ERROR =========="
            );


            Console.WriteLine(
                ex.ToString()
            );


            return BadRequest(new
            {
                message = ex.Message,

                inner =
                ex.InnerException?.Message
            });

        }

    }







    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] CreateJournalEntryRequest request)
    {

        try
        {

            var result =
                await _service.UpdateAsync(
                    id,
                    request
                );


            return Ok(result);

        }
        catch(Exception ex)
        {

            return BadRequest(new
            {
                message = ex.Message,

                inner =
                ex.InnerException?.Message
            });

        }

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
            message =
            "Journal Entry deleted"
        });

    }


}