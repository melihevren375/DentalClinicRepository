using Entities.DataTransferObjects.EmployeeTypeDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/EmployeeType")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class EmployeeTypeController : ControllerBase
{
    private readonly IEmployeeTypeService _employeeTypeervice;

    public EmployeeTypeController(IEmployeeTypeService employeeTypeervice)
    {
        _employeeTypeervice = employeeTypeervice;
    }

    [HttpGet("GetEmployeeTypeAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetEmployeeTypeAsync([FromQuery] EmployeeTypeParams employeeTypeParams)
    {
        var results = await _employeeTypeervice.GetEmployeeTypes(employeeTypeParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteEmployeeTypeAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteEmployeeTypeAsync([FromRoute(Name = "id")] Guid id)
    {
        await _employeeTypeervice.DeleteEmployeeTypeAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateEmployeeTypeAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateEmployeeTypeAsync([FromRoute(Name = "id")] Guid id, [FromBody] EmployeeTypeDtoForUpdate employeeTypeDtoForUpdate)
    {
        await _employeeTypeervice.UpdateEmployeeTypeAsync(id, true, employeeTypeDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateEmployeeTypeAsync")]
    public async Task<IActionResult> CreateEmployeeTypeAsync([FromBody] EmployeeTypeDtoForInsertion employeeTypeDtoForInsertion)
    {
        await _employeeTypeervice.CreateEmployeeTypeAsync(employeeTypeDtoForInsertion);
        return StatusCode(201, employeeTypeDtoForInsertion);
    }
}
