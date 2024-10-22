using Entities.DataTransferObjects.TreatmentTypeDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/TreatmentTypes")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class TreatmentTypesController : ControllerBase
{
    private readonly ITreatmentTypeService _treatmentTypeService;

    public TreatmentTypesController(ITreatmentTypeService treatmentTypeService)
    {
        _treatmentTypeService = treatmentTypeService;
    }

    [HttpGet("GetTreatmentTypesAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetTreatmentTypesAsync([FromQuery] TreatmentTypeParams treatmentTypeParams)
    {
        var results = await _treatmentTypeService.GetTreatmentTypes(treatmentTypeParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteTreatmentTypeAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteTreatmentTypeAsync([FromRoute(Name = "id")] Guid id)
    {
        await _treatmentTypeService.DeleteTreatmentTypeAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateTreatmentTypeAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateTreatmentTypeAsync([FromRoute(Name = "id")] Guid id, [FromBody] TreatmentTypeDtoForUpdate treatmentTypeDtoForUpdate)
    {
        await _treatmentTypeService.UpdateTreatmentTypeAsync(id, true, treatmentTypeDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateTreatmentTypeAsync")]
    public async Task<IActionResult> CreateTreatmentTypeAsync([FromBody] TreatmentTypeDtoForInsertion treatmentTypeDtoForInsertion)
    {
        await _treatmentTypeService.CreateTreatmentTypeAsync(treatmentTypeDtoForInsertion);
        return StatusCode(201, treatmentTypeDtoForInsertion);
    }
}
