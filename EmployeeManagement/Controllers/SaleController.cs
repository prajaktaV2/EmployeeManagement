using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetTop3ProductSale")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetTop3ProductSale()
        {

            var getList = await _saleService.GetTop3ProductSale();
            return Ok(getList);
        }

        [HttpGet("GetTotalSalePerMonthSale")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetTotalSalePerMonthSale()
        {

            var getList = await _saleService.GetTotalSalePerMonthSale();
            return Ok(getList);
        }

        [HttpGet("GetMostPopularProduct")]
        public async Task<ActionResult<Sale>> GetMostPopularProduct()
        {

            var getList = await _saleService.GetMostPopularProduct();
            return Ok(getList);
        }

        [HttpGet("GetLeastPopularProduct")]
        public async Task<ActionResult<Sale>> GetLeastPopularProduct()
        {

            var getList = await _saleService.GetLeastPopularProduct();
            return Ok(getList);
        }
        [HttpGet("GetLeastSoldProduct")]
        public async Task<ActionResult<Sale>> GetLeastSoldProduct()
        {

            var getList = await _saleService.GetLeastSoldProduct();
            return Ok(getList);
        }
        [HttpGet("GetMostSoldProduct")]
        public async Task<ActionResult<Sale>> GetMostSoldProduct()
        {

            var getList = await _saleService.GetMostSoldProduct();
            return Ok(getList);
        }
        [HttpGet("CalculateTotalQtySold")]
        public async Task<ActionResult<string>> CalculateTotalQtySold()
        {
            var getList = await _saleService.CalculateTotalQtySold();
            return Ok(getList);
        }
        [HttpGet("GetMostSoldProductEveryMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetMostSoldProductEveryMonth()
        {
            var getList = await _saleService.GetMostSoldProductEveryMonth();
            return Ok(getList);
        }
        [HttpGet("GetLeastSoldProductEveryMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetLeastSoldProductEveryMonth()
        {
            var getList = await _saleService.GetLeastSoldProductEveryMonth();
            return Ok(getList);
        }

        [HttpGet("GetAvgQtySoldProductEachMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAvgQtySoldProductEachMonth()
        {
            var getList = await _saleService.GetAvgQtySoldProductEachMonth();
            return Ok(getList);
        }
        [HttpGet("GetAggregateStatEachProduct")]
        public async Task<ActionResult<IEnumerable<object>>> GetAggregateStatEachProduct()
        {
            var getList = await _saleService.GetAggregateStatEachProduct();
            return Ok(getList);
        }
    }
}
