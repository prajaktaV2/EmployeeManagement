using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class ProductOrderService : IProductOrderService
    {
        public Task<List<CustomerActivity>> GetAllCustomerActivityAsync()
        {
            return Task.FromResult(DBData.CustomerActivities.ToList());
        }

        public Task<List<Inquiry>> GetAllInquiryAsync()
        {
            return Task.FromResult(DBData.MonthlyInquiries.ToList());
        }

        public Task<List<Order>> GetAllOrderAsync()
        {
            return Task.FromResult(DBData.Orders.ToList());
        }

        public Task<List<Purchase>> GetAllPurchaseAsync()
        {
            return Task.FromResult(DBData.Purchases.ToList());
        }

        public Task<List<Sale>> GetAllSaleAsync()
        {
            return Task.FromResult(DBData.MonthlySales.ToList());
        }

        public Task<List<SupportTicket>> GetAllSupportTicketAsync()
        {
            return Task.FromResult(DBData.MonthlySupportTickets.ToList());
        }
    }
        
}
