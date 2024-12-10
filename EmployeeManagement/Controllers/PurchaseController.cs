using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("GetPurchaseCustomerList")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchaseCustomerList()
        {

            var getPurchaseCustomerListList = await _purchaseService.GetPurchaseCustomerList();
            return Ok(getPurchaseCustomerListList);
        }

        [HttpGet("GetTotalAmountSpentByEachCustomer")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalAmountSpentByEachCustomer()
        {

            var getTotalAmountSpentByEachCustomerList = await _purchaseService.GetTotalAmountSpentByEachCustomer();
            return Ok(getTotalAmountSpentByEachCustomerList);
        }

        [HttpGet("GetTopCustomerAmtSpentEachMonth")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTopCustomerAmtSpentEachMonth()
        {

            var getTopCustomerAmtSpentEachMonthList = await _purchaseService.GetTopCustomerAmtSpentEachMonth();
            return Ok(getTopCustomerAmtSpentEachMonthList);
        }

        [HttpGet("GetMinMaxAvgAllCustomer")]
        public async Task<ActionResult<IEnumerable<object>>> GetMinMaxAvgAllCustomer()
        {

            var getMinMaxAvgAllCustomerList = await _purchaseService.GetMinMaxAvgAllCustomer();
            return Ok(getMinMaxAvgAllCustomerList);
        }
        [HttpGet("GetAvgAmtSpentEachMonth")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAvgAmtSpentEachMonth()
        {

            var getAvgAmtSpentEachMonthList = await _purchaseService.GetAvgAmtSpentEachMonth();
            return Ok(getAvgAmtSpentEachMonthList);
        }
        [HttpGet("GetGroupOfCustPurchase6Month")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetGroupOfCustPurchase6Month()
        {

            var getGroupOfCustPurchase6MonthList = await _purchaseService.GetGroupOfCustPurchase6Month();
            return Ok(getGroupOfCustPurchase6MonthList);
        }
        [HttpGet("GetMedianAmtSpent")]
        public async Task<ActionResult<double>> GetMedianAmtSpent()
        {

            var getMedianAmtSpentList = await _purchaseService.GetMedianAmtSpent();
            return Ok(getMedianAmtSpentList);
        }
        [HttpGet("GetHighestPurchaseDayWeek")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetHighestPurchaseDayWeek()
        {
            var getHighestPurchaseDayWeekList = await _purchaseService.GetHighestPurchaseDayWeek();
            return Ok(getHighestPurchaseDayWeekList);
        }
        [HttpGet("GetLowestPurchaseDayWeek")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetLowestPurchaseDayWeek()
        {
            var getLowestPurchaseDayWeekList = await _purchaseService.GetLowestPurchaseDayWeek();
            return Ok(getLowestPurchaseDayWeekList);
        }
        [HttpGet("GetTotalPurchaseWeekends")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalPurchaseWeekends()
        {
            var getTotalPurchaseWeekendsList = await _purchaseService.GetTotalPurchaseWeekends();
            return Ok(getTotalPurchaseWeekendsList);
        }
        [HttpGet("GetTotalPurchaseWeekdays")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalPurchaseWeekdays()
        {
            var getTotalPurchaseWeekdaysList = await _purchaseService.GetTotalPurchaseWeekdays();
            return Ok(getTotalPurchaseWeekdaysList);
        }
        [HttpGet("GetTotalPurchaseEachDayWeek")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalPurchaseEachDayWeek()
        {
            var getTotalPurchaseEachDayWeekList = await _purchaseService.GetTotalPurchaseEachDayWeek();
            return Ok(getTotalPurchaseEachDayWeekList);
        }
        [HttpGet("GetTotalPurchaseEachDayWeek3Months")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalPurchaseEachDayWeek3Months()
        {
            var getTotalPurchaseEachDayWeek3MonthsList = await _purchaseService.GetTotalPurchaseEachDayWeek3Months();
            return Ok(getTotalPurchaseEachDayWeek3MonthsList);
        }
        [HttpGet("GetAvgPurchaseEachDayWeek")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAvgPurchaseEachDayWeek()
        {
            var getAvgPurchaseEachDayWeekList = await _purchaseService.GetAvgPurchaseEachDayWeek();
            return Ok(getAvgPurchaseEachDayWeekList);
        }
        [HttpGet("GetPurchaseInformationforCustId3Months/{custId}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchaseInformationforCustId3Months(string custId)
        {
            var getPurchaseInformationforCustId3MonthsList = await _purchaseService.GetPurchaseInformationforCustId3Months(custId);
            return Ok(getPurchaseInformationforCustId3MonthsList);
        }
    }
}
