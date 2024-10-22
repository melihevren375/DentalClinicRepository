using Entities.DataTransferObjects.PaymentMethodDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/PaymentMethods")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class PaymentMethodsController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodsController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    [HttpGet("GetPaymentMethodsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetPaymentMethodsAsync([FromQuery] PaymentMethodParams paymentMethodParams)
    {
        var results = await _paymentMethodService.GetPaymentMethods(paymentMethodParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeletePaymentMethodAsync/{id:Guid}")]
    public async Task<IActionResult> DeletePaymentMethodAsync([FromRoute(Name = "id")] Guid id)
    {
        await _paymentMethodService.DeletePaymentMethodAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdatePaymentMethodAsync/{id:Guid}")]
    public async Task<IActionResult> UpdatePaymentMethodAsync([FromRoute(Name = "id")] Guid id, [FromBody] PaymentMethodDtoForUpdate paymentMethodDtoForUpdate)
    {
        await _paymentMethodService.UpdatePaymentMethodAsync(id, true, paymentMethodDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreatePaymentMethodAsync")]
    public async Task<IActionResult> CreatePaymentMethodAsync([FromBody] PaymentMethodDtoForInsertion paymentMethodDtoForInsertion)
    {
        await _paymentMethodService.CreatePaymentMethodAsync(paymentMethodDtoForInsertion);
        return StatusCode(201, paymentMethodDtoForInsertion);
    }
}
