using Entities.DataTransferObjects.ClinicalAssistantDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/clinicalAssistans")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class ClinicalAssistansController : ControllerBase
{
    private readonly IClinicalAsistantService _clinicalAssistanService;

    public ClinicalAssistansController(IClinicalAsistantService clinicalAssistanService)
    {
        _clinicalAssistanService = clinicalAssistanService;
    }

    [HttpGet("GetClinicalAssistansAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetClinicalAssistansAsync([FromQuery] ClinicalAssistantParams clinicalAssistanParams)
    {
        var results = await _clinicalAssistanService.GetClinicalAssistants(clinicalAssistanParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteClinicalAssistanAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteClinicalAssistanAsync([FromRoute(Name = "id")] Guid id)
    {
        await _clinicalAssistanService.DeleteClinicalAssistantAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateClinicalAssistanAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateClinicalAssistanAsync([FromRoute(Name = "id")] Guid id, [FromBody] ClinicalAssistantDtoUpdate clinicalAssistanDtoForUpdate)
    {
        await _clinicalAssistanService.UpdateClinicalAssistantAsync(id, true, clinicalAssistanDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateClinicalAssistanAsync")]
    public async Task<IActionResult> CreateClinicalAssistanAsync([FromBody] ClinicalAssistantDtoInsertion clinicalAssistanDtoForInsertion)
    {
        await _clinicalAssistanService.CreateClinicalAssistantAsync(clinicalAssistanDtoForInsertion);
        return StatusCode(201, clinicalAssistanDtoForInsertion);
    }
}
