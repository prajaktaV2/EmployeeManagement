using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IInquiryService
    {
        public Task<List<Inquiry>> GetNoOfInquiryPerCategory3Month();
        public Task<List<Inquiry>> GetDateHadHighestNoInquiry();
        public Task<List<Inquiry>> GetProductCategoryHighestNoInquiry3Month();
    }
}
