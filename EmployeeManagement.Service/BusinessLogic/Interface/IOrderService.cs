using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IOrderService
    {
        public Task<List<string>> GetCustIdMadePurchaseInAfternoon();
        public Task<List<string>> GetCustIdMadePurchaseInMorning();
        public Task<List<string>> GetCustIdMadePurchaseInEvening();
        public Task<int> GetTotalNoMadePurchaseInMorning();
        public Task<int> GetTotalNoMadePurchaseInAfterNoon();
        public Task<int> GetTotalNoMadePurchaseInEvening();
        public Task<List<OrderPurchaseViewModel>> GetOrderPurchaseInfo(string custId);
        public Task<List<Order>> GetOrderInfo(string custId);
        public Task<int> GetTotalOrderIn3Month();
        public Task<List<Order>> GetTotalUniqueCustomerOrderIn3Month();
    }
}
