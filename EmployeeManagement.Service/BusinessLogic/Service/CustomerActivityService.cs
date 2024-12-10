using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class CustomerActivityService : ICustomerActivityService
    {
        private readonly IProductOrderService _productOrderService;
        public CustomerActivityService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        public async Task<List<string>> GetMostActiveCustomer3Months()
        {
            // find the most active customer in the last 3 months
            var customerActivity= await _productOrderService.GetAllCustomerActivityAsync();
            var getActiveCustomer3Months = customerActivity.Where(x => x.CustomerActivityDate >= DateTime.Now.AddMonths(-3))
                                            .GroupBy(x => x.CustomerId)
                                            .Select(group => group.Key)
                                            .ToList();
            return getActiveCustomer3Months;
        }

        public async Task<List<CustomerActivity>> GetUniqueCustomer3Months()
        {
            // get unique customers who have interacted with the platform in the last 3 months
            var customerActivity = await _productOrderService.GetAllCustomerActivityAsync();
            var getUniqueCustomer3Months = customerActivity
                                            .Where(x => x.CustomerActivityDate >= DateTime.Now.AddMonths(-3))
                                            .DistinctBy(x=>x.CustomerId).ToList();
            return getUniqueCustomer3Months; 
        }
    }
}
