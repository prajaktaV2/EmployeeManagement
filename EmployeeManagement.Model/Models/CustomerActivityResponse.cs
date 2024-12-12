using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class CustomerActivityResponse
    {
        public string CustomerId { get; set; } = string.Empty;
        public string LoyaltyTier { get; set; } = string.Empty;
    }
}
