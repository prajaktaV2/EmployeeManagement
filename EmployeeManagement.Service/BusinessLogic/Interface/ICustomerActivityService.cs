using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface ICustomerActivityService
    {
        public Task<List<CustomerActivity>> GetUniqueCustomer3Months();
        public Task<List<string>> GetMostActiveCustomer3Months();
    }
}
