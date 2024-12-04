using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IPurchaseService
    {
        public Task<List<Purchase>> GetPurchaseCustomerList();
        public Task<List<Purchase>> GetTotalAmountSpentByEachCustomer();
        public Task<List<Purchase>> GetTopCustomerAmtSpentEachMonth();
        public Task<List<object>> GetMinMaxAvgAllCustomer();
        public Task<List<Purchase>> GetAvgAmtSpentEachMonth();
        public Task<List<Purchase>> GetGroupOfCustPurchase6Month();
        public Task<double> GetMedianAmtSpent();
    }
}
