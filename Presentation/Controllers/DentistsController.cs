using Entities.DataTransferObjects.DentistDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Dentists")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class DentistsController : ControllerBase
{
    private readonly IDentistService _dentistService;

    public DentistsController(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    [HttpGet("GetDentistsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetDentistsAsync([FromQuery] DentistParams dentistParams)
    {
        var results = await _dentistService.GetDentists(dentistParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteDentistAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteDentistAsync([FromRoute(Name = "id")] Guid id)
    {
        await _dentistService.DeleteDentistAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateDentistAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateDentistAsync([FromRoute(Name = "id")] Guid id, [FromBody] DentistDtoForUpdate dentistDtoForUpdate)
    {
        await _dentistService.UpdateDentistAsync(id, true, dentistDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateDentistAsync")]
    public async Task<IActionResult> CreateDentistAsync([FromBody] DentistDtoForInsertion dentistDtoForInsertion)
    {
        await _dentistService.CreateDentistAsync(dentistDtoForInsertion);
        return StatusCode(201, dentistDtoForInsertion);
    }
}
