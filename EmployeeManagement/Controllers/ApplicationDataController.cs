using System.Collections.Generic;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationDataController : ControllerBase
    {
        private readonly IApplicationDataService _applicationDataService;
        public ApplicationDataController(IApplicationDataService applicationDataService)
        {
            _applicationDataService = applicationDataService;
        }

        [HttpGet("GetProductSalesVolumeEachSeason/{num}")]
        public async Task<ActionResult<IEnumerable<ComplaintResponse>>> GetProductSalesVolumeEachSeason(int num)
        {
            try
            {
                var complaints = await _applicationDataService.GetProductSalesVolumeEachSeason(num);
                return Ok(complaints);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetListOfMajorComplaintRaised")]
        public async Task<ActionResult<IEnumerable<ComplaintResponse>>> GetListOfMajorComplaintRaised()
        {
            try
            {
                var complaints = await _applicationDataService.GetListOfMajorComplaintRaised();
                return Ok(complaints);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetListOfEachCustomerLoyaltyTier")]
        public async Task<ActionResult<IEnumerable<CustomerActivityResponse>>> GetListOfEachCustomerLoyaltyTier()
        { 
            try
            {
                var loyaltyCustomer = await _applicationDataService.GetListOfEachCustomerLoyaltyTier();
                return Ok(loyaltyCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetListOfProductWithOrderCountEachMonth/{year}")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetListOfProductWithOrderCountEachMonth(int year)
        {
            try
            {
                var products = await _applicationDataService.GetListOfProductWithOrderCountEachMonth(year);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
    }
}
