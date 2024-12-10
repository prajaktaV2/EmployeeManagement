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
            var getAvgSupportTicket3MonthsList = await _supportTicketService.GetAvgSupportTicket3Months();
            return Ok(getAvgSupportTicket3MonthsList);
        }
        [HttpGet("GetDuplicateSupportTicket")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetDuplicateSupportTicket()
        {
            var getDuplicateSupportTicketList = await _supportTicketService.GetDuplicateSupportTicket();
            return Ok(getDuplicateSupportTicketList);
        }
        [HttpGet("GetSupportTicketCategory3Month")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTicketCategory3Month()
        {
            var getSupportTicketCategory3MonthList = await _supportTicketService.GetSupportTicketCategory3Month();
            return Ok(getSupportTicketCategory3MonthList);
        }
        [HttpGet("GetSupportTicket3Month")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTicket3Month()
        {
            var getSupportTicket3MonthList = await _supportTicketService.GetSupportTicket3Month();
            return Ok(getSupportTicket3MonthList);
        }
        [HttpGet("GetAvgSupportTicketPerMonth")]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAvgSupportTicketPerMonth()
        {
            var getAvgSupportTicketPerMonthList = await _supportTicketService.GetAvgSupportTicketPerMonth();
            return Ok(getAvgSupportTicketPerMonthList);
        }
        [HttpGet("GetHighestSupportTicket")]
        public async Task<ActionResult<SupportTicket>> GetHighestSupportTicket()
        {
            var getHighestSupportTicketList = await _supportTicketService.GetHighestSupportTicket();
            return Ok(getHighestSupportTicketList);
        }
    }
}
