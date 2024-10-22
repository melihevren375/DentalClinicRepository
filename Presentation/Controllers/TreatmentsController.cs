using Entities.DataTransferObjects.TreatmentDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Treatments")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class TreatmentsController : ControllerBase
{
    private readonly ITreatmentService _treatmentService;

    public TreatmentsController(ITreatmentService treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpGet("GetTreatmentsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetTreatmentsAsync([FromQuery] TreatmentParams treatmentParams)
    {
        var results = await _treatmentService.GetTreatments(treatmentParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteTreatmentAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteTreatmentAsync([FromRoute(Name = "id")] Guid id)
    {
        await _treatmentService.DeleteTreatmentAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateTreatmentAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateTreatmentAsync([FromRoute(Name = "id")] Guid id, [FromBody] TreatmentDtoForUpdate treatmentDtoForUpdate)
    {
        await _treatmentService.UpdateTreatmentAsync(id, true, treatmentDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateTreatmentAsync")]
    public async Task<IActionResult> CreateTreatmentAsync([FromBody] TreatmentDtoForInsertion treatmentDtoForInsertion)
    {
        await _treatmentService.CreateTreatmentAsync(treatmentDtoForInsertion);
        return StatusCode(201, treatmentDtoForInsertion);
    }
}
