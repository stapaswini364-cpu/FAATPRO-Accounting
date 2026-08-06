using Microsoft.AspNetCore.Mvc;

using FAATPRO.Application.DTOs.PaymentVoucher;
using FAATPRO.Infrastructure.Services.PaymentVoucher;


namespace FAATPRO.API.Controllers.PaymentVoucher;


[ApiController]
[Route("api/[controller]")]
public class PaymentVoucherController : ControllerBase
{

    private readonly PaymentVoucherService _service;



    public PaymentVoucherController(
        PaymentVoucherService service)
    {
        _service = service;
    }




    // ==========================================
    // CREATE PAYMENT VOUCHER
    // ==========================================

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePaymentVoucherRequest request)
    {

        var id =
            await _service.CreateAsync(request);



        return Ok(new
        {
            success = true,

            message =
                "Payment Voucher Created Successfully",

            id
        });

    }

}