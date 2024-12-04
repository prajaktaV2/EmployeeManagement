using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IProductOrderService
    {
        public Task<List<Purchase>> GetAllPurchaseAsync();
        public Task<List<Sale>> GetAllSaleAsync();
        public Task<List<Order>> GetAllOrderAsync();
        public Task<List<Inquiry>> GetAllInquiryAsync();
        public Task<List<SupportTicket>> GetAllSupportTicketAsync();
        public Task<List<CustomerActivity>> GetAllCustomerActivityAsync();
    }
}
