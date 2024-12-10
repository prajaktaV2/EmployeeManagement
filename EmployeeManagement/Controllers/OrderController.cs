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
            var getCustIdMadePurchaseInAfternoonList = await _orderService.GetCustIdMadePurchaseInAfternoon();
            return Ok(getCustIdMadePurchaseInAfternoonList);
        }
        [HttpGet("GetCustIdMadePurchaseInMorning")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustIdMadePurchaseInMorning()
        {
            var getCustIdMadePurchaseInMorningList = await _orderService.GetCustIdMadePurchaseInMorning();
            return Ok(getCustIdMadePurchaseInMorningList);
        }
        [HttpGet("GetCustIdMadePurchaseInEvening")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustIdMadePurchaseInEvening()
        {
            var getCustIdMadePurchaseInEveningList = await _orderService.GetCustIdMadePurchaseInEvening();
            return Ok(getCustIdMadePurchaseInEveningList);
        }
        [HttpGet("GetTotalNoMadePurchaseInMorning")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInMorning()
        {
            var getTotalNoMadePurchaseInMorning = await _orderService.GetTotalNoMadePurchaseInMorning();
            return Ok(getTotalNoMadePurchaseInMorning);
        }
        [HttpGet("GetTotalNoMadePurchaseInAfterNoon")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInAfterNoon()
        {
            var getTotalNoMadePurchaseInAfterNoon = await _orderService.GetTotalNoMadePurchaseInAfterNoon();
            return Ok(getTotalNoMadePurchaseInAfterNoon);
        }
        [HttpGet("GetTotalNoMadePurchaseInEvening")]
        public async Task<ActionResult<int>> GetTotalNoMadePurchaseInEvening()
        {
            var getTotalNoMadePurchaseInEvening = await _orderService.GetTotalNoMadePurchaseInEvening();
            return Ok(getTotalNoMadePurchaseInEvening);
        }
        [HttpGet("GetOrderPurchaseInfo/{custId}")]
        public async Task<ActionResult<IEnumerable<OrderPurchaseViewModel>>> GetOrderPurchaseInfo(string custId)
        {
            var getOrderPurchaseInfoList = await _orderService.GetOrderPurchaseInfo(custId);
            return Ok(getOrderPurchaseInfoList);
        }
        [HttpGet("GetOrderInfo/{custId}")]
        public async Task<ActionResult<int>> GetOrderInfo(string custId)
        {
            var getOrderInfo = await _orderService.GetOrderInfo(custId);
            return Ok(getOrderInfo);
        }
        [HttpGet("GetTotalOrderIn3Month")]
        public async Task<ActionResult<int>> GetTotalOrderIn3Month()
        {
            var getTotalOrderIn3Month = await _orderService.GetTotalOrderIn3Month();
            return Ok(getTotalOrderIn3Month);
        }
        [HttpGet("GetTotalUniqueCustomerOrderIn3Month")]
        public async Task<ActionResult<IEnumerable<Order>>> GetTotalUniqueCustomerOrderIn3Month()
        {
            var getTotalUniqueCustomerOrderIn3MonthList = await _orderService.GetTotalUniqueCustomerOrderIn3Month();
            return Ok(getTotalUniqueCustomerOrderIn3MonthList);
        }
        [HttpGet("GetTotalNoOrderPlacedPerMonth3Month")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetTotalNoOrderPlacedPerMonth3Month()
        {
            var getTotalNoOrderPlacedPerMonth3MonthList = await _orderService.GetTotalNoOrderPlacedPerMonth3Month();
            return Ok(getTotalNoOrderPlacedPerMonth3MonthList);
        }

    }
}
