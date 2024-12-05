using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerActivityController : ControllerBase
    {
        private readonly ICustomerActivityService _customerActivityService;
        public CustomerActivityController(ICustomerActivityService customerActivityService)
        {
            _customerActivityService = customerActivityService;
        }

        [HttpGet("GetUniqueCustomer3Months")]
        public async Task<ActionResult<IEnumerable<CustomerActivity>>> GetUniqueCustomer3Months()
        {
            var getList = await _customerActivityService.GetUniqueCustomer3Months();
            return Ok(getList);
        }
        [HttpGet("GetMostActiveCustomer3Months")]
        public async Task<ActionResult<IEnumerable<CustomerActivity>>> GetMostActiveCustomer3Months()
        {
            var getList = await _customerActivityService.GetMostActiveCustomer3Months();
            return Ok(getList);
        }
    }
}
