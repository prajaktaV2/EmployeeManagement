using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class OrderResponse
    {
        
        public string ProductId { get; set; } = string.Empty;
        public string Product { get; set; }=string.Empty;
        public Dictionary<string, int> monthlyOrders { get; set; } = new Dictionary<string, int>();
    }
}
