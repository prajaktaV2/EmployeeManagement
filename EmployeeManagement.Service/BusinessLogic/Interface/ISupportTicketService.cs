using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface ISupportTicketService
    {
        public Task<List<ViewModel>> GetAvgSupportTicket3Months();
        public Task<List<ViewModel>> GetDuplicateSupportTicket();
        public Task<List<ViewModel>> GetSupportTicketCategory3Month();
        public Task<List<ViewModel>> GetSupportTicket3Month();
        public Task<List<ViewModel>> GetAvgSupportTicketPerMonth();
        public Task<ViewModel> GetHighestSupportTicket();
    }
}
