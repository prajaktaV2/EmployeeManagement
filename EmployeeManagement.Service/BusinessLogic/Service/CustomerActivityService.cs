using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class CustomerActivityService : ICustomerActivityService
    {
        public Task<List<CustomerActivity>> GetMostActiveCustomer3Months()
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerActivity>> GetUniqueCustomer3Months()
        {
            throw new NotImplementedException();
        }
    }
}
