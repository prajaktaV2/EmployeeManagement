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
        public static DateTime maxCustomerActivityDate = DBData.CustomerActivities.Max(p => p.CustomerActivityDate);
        public static DateTime minCustomerActivityDate = DBData.CustomerActivities.Min(p => p.CustomerActivityDate);

        public static DateTime threeMonthsAgo = DBData.CustomerActivities.Max(x => x.CustomerActivityDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.CustomerActivities.Min(x => x.CustomerActivityDate).AddMonths(3);
        public Task<List<CustomerActivity>> GetMostActiveCustomer3Months()
        {
            // find the most active customer in the last 3 months
            var getActiveCustomer3Months = DBData.CustomerActivities.Where(x => x.CustomerActivityDate > threeMonthsAgo && x.CustomerActivityDate < maxCustomerActivityDate)
                                            .GroupBy(x => x.CustomerId)
                                            .OrderByDescending(group => group.Count())
                                            .ToList();
            return Task.FromResult(new List<CustomerActivity>());
        }

        public Task<List<CustomerActivity>> GetUniqueCustomer3Months()
        {
            // get unique customers who have interacted with the platform in the last 3 months
            var getUniqueCustomer3Months = DBData.CustomerActivities
                                            .Where(x => x.CustomerActivityDate > threeMonthsAgo && x.CustomerActivityDate < maxCustomerActivityDate)
                                            .Distinct().ToList();
            return Task.FromResult(getUniqueCustomer3Months); 
        }
    }
}
