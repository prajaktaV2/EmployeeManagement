﻿using EmployeeManagement.Model.Models;
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

            var getList = await _purchaseService.GetPurchaseCustomerList();
            return Ok(getList);
        }

        [HttpGet("GetTotalAmountSpentByEachCustomer")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTotalAmountSpentByEachCustomer()
        {

            var getList = await _purchaseService.GetTotalAmountSpentByEachCustomer();
            return Ok(getList);
        }

        [HttpGet("GetTopCustomerAmtSpentEachMonth")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetTopCustomerAmtSpentEachMonth()
        {

            var getList = await _purchaseService.GetTopCustomerAmtSpentEachMonth();
            return Ok(getList);
        }

        [HttpGet("GetMinMaxAvgAllCustomer")]
        public async Task<ActionResult<IEnumerable<object>>> GetMinMaxAvgAllCustomer()
        {

            var getList = await _purchaseService.GetMinMaxAvgAllCustomer();
            return Ok(getList);
        }
        [HttpGet("GetAvgAmtSpentEachMonth")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAvgAmtSpentEachMonth()
        {

            var getList = await _purchaseService.GetAvgAmtSpentEachMonth();
            return Ok(getList);
        }
        [HttpGet("GetGroupOfCustPurchase6Month")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetGroupOfCustPurchase6Month()
        {

            var getList = await _purchaseService.GetGroupOfCustPurchase6Month();
            return Ok(getList);
        }
        [HttpGet("GetMedianAmtSpent")]
        public async Task<ActionResult<double>> GetMedianAmtSpent()
        {

            var getList = await _purchaseService.GetMedianAmtSpent();
            return Ok(getList);
        }
    }
}
