using EmployeeManagement.Model.Models;
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
            var customerActivities = await _productOrderService.GetAllCustomerActivityAsync();
            return Ok(customerActivities);
        }

        [HttpGet("GetAllInquiry")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllInquiry()
        {
            var inquiries = await _productOrderService.GetAllInquiryAsync();
            return Ok(inquiries);
        }

        [HttpGet("GetAllPurchase")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllPurchase()
        {
            var purchase = await _productOrderService.GetAllPurchaseAsync();
            return Ok(purchase);
        }

        [HttpGet("GetAllSupportTicket")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllSupportTicket()
        {
            var supportTickets = await _productOrderService.GetAllSupportTicketAsync();
            return Ok(supportTickets);
        }
    }
}
