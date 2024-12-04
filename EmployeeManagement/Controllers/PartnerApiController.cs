using EmployeeManagement.Model.Models;
using EmployeeManagement.Model.Models.PartnerApi;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerApiController : ControllerBase
    {
        private readonly IPartnerApiService _partnerApiService;
        public PartnerApiController(IPartnerApiService partnerApiService)
        {
            _partnerApiService = partnerApiService;
        }


        [HttpGet("/products/partner")]
        public async Task<ActionResult<IEnumerable<Products>>> GetPartnerProduct([FromQuery] int limit)
        {
            try
            {
                if (limit <= 0) return BadRequest("Limit should greater than 0");
                var products = await _partnerApiService.GetPartnerProduct(limit);
                if (products == null) return NotFound();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
