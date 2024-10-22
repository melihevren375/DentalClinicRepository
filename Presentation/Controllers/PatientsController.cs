using Entities.DataTransferObjects.PatientDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Patients")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("GetPatientsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetPatientsAsync([FromQuery] PatientParams patientParams)
    {
        var results = await _patientService.GetPatients(patientParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeletePatientAsync/{id:Guid}")]
    public async Task<IActionResult> DeletePatientAsync([FromRoute(Name = "id")] Guid id)
    {
        await _patientService.DeletePatientAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdatePatientAsync/{id:Guid}")]
    public async Task<IActionResult> UpdatePatientAsync([FromRoute(Name = "id")] Guid id, [FromBody] PatientDtoForUpdate patientDtoForUpdate)
    {
        await _patientService.UpdatePatientAsync(id, true, patientDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreatePatientAsync")]
    public async Task<IActionResult> CreatePatientAsync([FromBody] PatientDtoForInsertion patientDtoForInsertion)
    {
        await _patientService.CreatePatientAsync(patientDtoForInsertion);
        return StatusCode(201, patientDtoForInsertion);
    }
}
