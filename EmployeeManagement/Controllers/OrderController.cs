using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetCustIdMadePurchaseInAfternoon")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustIdMadePurchaseInAfternoon()
        {
            var getList = await _orderService.GetCustIdMadePurchaseInAfternoon();
            return Ok(getList);
        }
        [HttpGet("GetCustIdMadePurchaseInMorning")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustIdMadePurchaseInMorning()
        {
            var getList = await _orderService.GetCustIdMadePurchaseInMorning();
            return Ok(getList);
        }
        [HttpGet("GetCustIdMadePurchaseInEvening")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustIdMadePurchaseInEvening()
        {
            var getList = await _orderService.GetCustIdMadePurchaseInEvening();
            return Ok(getList);
        }
        [HttpGet("GetTotalNoMadePurchaseInMorning")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInMorning()
        {
            var getList = await _orderService.GetTotalNoMadePurchaseInMorning();
            return Ok(getList);
        }
        [HttpGet("GetTotalNoMadePurchaseInAfterNoon")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInAfterNoon()
        {
            var getList = await _orderService.GetTotalNoMadePurchaseInAfterNoon();
            return Ok(getList);
        }
        [HttpGet("GetTotalNoMadePurchaseInEvening")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInEvening()
        {
            var getList = await _orderService.GetTotalNoMadePurchaseInEvening();
            return Ok(getList);
        }
        [HttpGet("GetOrderPurchaseInfo/{custId}")]
        public async Task<ActionResult<IEnumerable<OrderPurchaseViewModel>>> GetOrderPurchaseInfo(string custId)
        {
            var getList = await _orderService.GetOrderPurchaseInfo(custId);
            return Ok(getList);
        }
        [HttpGet("GetOrderInfo/{custId}")]
        public async Task<ActionResult<int>> GetOrderInfo(string custId)
        {
            var getList = await _orderService.GetOrderInfo(custId);
            return Ok(getList);
        }
        [HttpGet("GetTotalOrderIn3Month")]
        public async Task<ActionResult<int>> GetTotalOrderIn3Month()
        {
            var getList = await _orderService.GetTotalOrderIn3Month();
            return Ok(getList);
        }
        [HttpGet("GetTotalUniqueCustomerOrderIn3Month")]
        public async Task<ActionResult<IEnumerable<Order>>> GetTotalUniqueCustomerOrderIn3Month()
        {
            var getList = await _orderService.GetTotalUniqueCustomerOrderIn3Month();
            return Ok(getList);
        }


    }
}
