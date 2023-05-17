using Microsoft.AspNetCore.Mvc;
using Sample.Domains.Models;
using Sample.Services;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> CreateAsync([FromBody] EmployeeModel employeeModel)
        {
            try
            {
                var result = await _employeeService.CreateAsync(employeeModel);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAsync([FromBody] EmployeeFilterModel employeeFilterModel)
        {
            try
            {
                var result = await _employeeService.GetAllByFilterAsync(employeeFilterModel);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
