﻿using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        private readonly IProductOrderService _productOrderService;
        public ProductOrderController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _productOrderService.GetAllOrderAsync();
            return Ok(orders);
        }

        [HttpGet("GetAllSales")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllSales()
        {
            var sales = await _productOrderService.GetAllSaleAsync();
            return Ok(sales);
        }

        [HttpGet("GetAllCustomerActivity")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllCustomerActivity()
        {
            var sales = await _productOrderService.GetAllCustomerActivityAsync();
            return Ok(sales);
        }

        [HttpGet("GetAllInquiry")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllInquiry()
        {
            var sales = await _productOrderService.GetAllInquiryAsync();
            return Ok(sales);
        }

        [HttpGet("GetAllPurchase")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllPurchase()
        {
            var sales = await _productOrderService.GetAllPurchaseAsync();
            return Ok(sales);
        }

        [HttpGet("GetAllSupportTicket")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllSupportTicket()
        {
            var sales = await _productOrderService.GetAllSupportTicketAsync();
            return Ok(sales);
        }
    }
}
