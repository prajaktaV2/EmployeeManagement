using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;
using EmployeeManagement.Service.BusinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryService _inquiryService;
        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        [HttpGet("GetNoOfInquiryPerCategory3Month")]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetNoOfInquiryPerCategory3Month()
        {
            var getList = await _inquiryService.GetNoOfInquiryPerCategory3Month();
            return Ok(getList);
        }
        [HttpGet("GetDateHadHighestNoInquiry")]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetDateHadHighestNoInquiry()
        {
            var getList = await _inquiryService.GetDateHadHighestNoInquiry();
            return Ok(getList);
        }
    }
}
