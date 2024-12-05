using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IApplicationDataService
    {
        public Task<List<SalesResponse>> GetProductSalesVolumeEachSeason(int num);
        public Task<List<OrderResponse>> GetListOfProductWithOrderCountEachMonth(int year);
        public Task<List<ComplaintResponse>> GetListOfMajorComplaintRaised();
        public Task<List<CustomerActivityResponse>> GetListOfEachCustomerLoyaltyTier();
    }
}
