using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class CustomerActivity
    {
        public string CustomerId { get; set; }
        public DateTime CustomerActivityDate { get; set; }
        public CustomerActivity(string customerId, DateTime customerActivityDate)
        {  
            CustomerId = customerId; 
            CustomerActivityDate = customerActivityDate; 
        }
    }
}
