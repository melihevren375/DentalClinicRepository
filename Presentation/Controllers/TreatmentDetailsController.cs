using Entities.DataTransferObjects.TreatmentDetailsDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/TreatmentDetails")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class TreatmentDetailsController : ControllerBase
{
    private readonly ITreatmentDetailService _treatmentDetailService;

    public TreatmentDetailsController(ITreatmentDetailService treatmentDetailService)
    {
        _treatmentDetailService = treatmentDetailService;
    }

    [HttpGet("GetTreatmentDetailsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetTreatmentDetailsAsync([FromQuery] TreatmentDetailsParams treatmentDetailParams)
    {
        var results = await _treatmentDetailService.GetTreatmentDetails(treatmentDetailParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteTreatmentDetailAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteTreatmentDetailAsync([FromRoute(Name = "id")] Guid id)
    {
        await _treatmentDetailService.DeleteTreatmentDetailAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateTreatmentDetailAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateTreatmentDetailAsync([FromRoute(Name = "id")] Guid id, [FromBody] TreatmentDetailsDtoForUpdate treatmentDetailDtoForUpdate)
    {
        await _treatmentDetailService.UpdateTreatmentDetailAsync(id, true, treatmentDetailDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateTreatmentDetailAsync")]
    public async Task<IActionResult> CreateTreatmentDetailAsync([FromBody] TreatmentDetailsDtoForInsertion treatmentDetailDtoForInsertion)
    {
        await _treatmentDetailService.CreateTreatmentDetailAsync(treatmentDetailDtoForInsertion);
        return StatusCode(201, treatmentDetailDtoForInsertion);
    }
}
