using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        private readonly ISupportTicketService _supportTicketService;
        public SupportTicketController(ISupportTicketService supportTicketService)
        {
            _supportTicketService = supportTicketService;
        }

        [HttpGet("GetAvgSupportTicket3Months")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAvgSupportTicket3Months()
        {
            var getList = await _supportTicketService.GetAvgSupportTicket3Months();
            return Ok(getList);
        }
        [HttpGet("GetDuplicateSupportTicket")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetDuplicateSupportTicket()
        {
            var getList = await _supportTicketService.GetDuplicateSupportTicket();
            return Ok(getList);
        }
        [HttpGet("GetSupportTicketCategory3Month")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTicketCategory3Month()
        {
            var getList = await _supportTicketService.GetSupportTicketCategory3Month();
            return Ok(getList);
        }
        [HttpGet("GetSupportTicket3Month")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTicket3Month()
        {
            var getList = await _supportTicketService.GetSupportTicket3Month();
            return Ok(getList);
        }
        [HttpGet("GetAvgSupportTicketPerMonth")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAvgSupportTicketPerMonth()
        {
            var getList = await _supportTicketService.GetAvgSupportTicketPerMonth();
            return Ok(getList);
        }
        [HttpGet("GetHighestSupportTicket")]
        public async Task<ActionResult<SupportTicket>> GetHighestSupportTicket()
        {
            var getList = await _supportTicketService.GetHighestSupportTicket();
            return Ok(getList);
        }
    }
}
