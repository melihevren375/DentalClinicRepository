using Entities.DataTransferObjects.AppointmentDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/appointments")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("GetAppointmentsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetAppointmentsAsync([FromQuery] AppointmentParams appointmentParams)
    {
        var results = await _appointmentService.GetAppointments(appointmentParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteAppointmentAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteAppointmentAsync([FromRoute(Name = "id")] Guid id)
    {
        await _appointmentService.DeleteAppointmentAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateAppointmentAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateAppointmentAsync([FromRoute(Name = "id")] Guid id, [FromBody] AppointmentDtoForUpdate appointmentDtoForUpdate)
    {
        await _appointmentService.UpdateAppointmentAsync(id, true, appointmentDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateAppointmentAsync")]
    public async Task<IActionResult> CreateAppointmentAsync([FromBody] AppointmentDtoForInsertion appointmentDtoForInsertion)
    {
        await _appointmentService.CreateAppointmentAsync(appointmentDtoForInsertion);
        return StatusCode(201, appointmentDtoForInsertion);
    }
}
