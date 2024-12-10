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

            var getTop3ProductSaleList = await _saleService.GetTop3ProductSale();
            return Ok(getTop3ProductSaleList);
        }

        [HttpGet("GetTotalSalePerMonthSale")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetTotalSalePerMonthSale()
        {

            var getTotalSalePerMonthSaleList = await _saleService.GetTotalSalePerMonthSale();
            return Ok(getTotalSalePerMonthSaleList);
        }

        [HttpGet("GetMostPopularProduct")]
        public async Task<ActionResult<Sale>> GetMostPopularProduct()
        {

            var getMostPopularProductList = await _saleService.GetMostPopularProduct();
            return Ok(getMostPopularProductList);
        }

        [HttpGet("GetLeastPopularProduct")]
        public async Task<ActionResult<Sale>> GetLeastPopularProduct()
        {

            var getLeastPopularProductList = await _saleService.GetLeastPopularProduct();
            return Ok(getLeastPopularProductList);
        }
        [HttpGet("GetLeastSoldProduct")]
        public async Task<ActionResult<Sale>> GetLeastSoldProduct()
        {

            var getLeastSoldProductList = await _saleService.GetLeastSoldProduct();
            return Ok(getLeastSoldProductList);
        }
        [HttpGet("GetMostSoldProduct")]
        public async Task<ActionResult<Sale>> GetMostSoldProduct()
        {

            var getMostSoldProductList = await _saleService.GetMostSoldProduct();
            return Ok(getMostSoldProductList);
        }
        [HttpGet("CalculateTotalQtySold")]
        public async Task<ActionResult<string>> CalculateTotalQtySold()
        {
            var getCalculateTotalQtySoldList = await _saleService.CalculateTotalQtySold();
            return Ok(getCalculateTotalQtySoldList);
        }
        [HttpGet("GetMostSoldProductEveryMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetMostSoldProductEveryMonth()
        {
            var getMostSoldProductEveryMonthList = await _saleService.GetMostSoldProductEveryMonth();
            return Ok(getMostSoldProductEveryMonthList);
        }
        [HttpGet("GetLeastSoldProductEveryMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetLeastSoldProductEveryMonth()
        {
            var getLeastSoldProductEveryMonthList = await _saleService.GetLeastSoldProductEveryMonth();
            return Ok(getLeastSoldProductEveryMonthList);
        }

        [HttpGet("GetAvgQtySoldProductEachMonth")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAvgQtySoldProductEachMonth()
        {
            var getAvgQtySoldProductEachMonthList = await _saleService.GetAvgQtySoldProductEachMonth();
            return Ok(getAvgQtySoldProductEachMonthList);
        }
        [HttpGet("GetAggregateStatEachProduct")]
        public async Task<ActionResult<IEnumerable<object>>> GetAggregateStatEachProduct()
        {
            var getAggregateStatEachProductList = await _saleService.GetAggregateStatEachProduct();
            return Ok(getAggregateStatEachProductList);
        }
    }
}
