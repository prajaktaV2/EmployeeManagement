using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("query")]
        public async Task<ActionResult<Employee>> GetEmployeeByRequestQueryId([FromQuery] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("combined/{id}")]
        public async Task<ActionResult> GetEmployeeDetailsCombined(int id, [FromQuery] int id1)
        {
            try
            {
                var employeeByIdTask = Task.Run(() => GetEmployeeById(id));  
                var employeeByQueryIdTask = Task.Run(() => GetEmployeeByRequestQueryId(id1));  

                var employeeById = await employeeByIdTask;
                var employeeByQueryId = await employeeByQueryIdTask;

                if (employeeById.Result is NotFoundResult && employeeByQueryId.Result is NotFoundResult)
                {
                    return NotFound();
                }

                return Ok(new[]
                {
                    (employeeById.Result as OkObjectResult)?.Value,
                    (employeeByQueryId.Result as OkObjectResult)?.Value
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmpId }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                if (id != employee.EmpId)
                {
                    return BadRequest();
                }
                await _employeeService.UpdateEmployeeAsync(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
