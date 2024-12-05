using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class OrderResponse
    {
        public int Month { get; set; }
        public string Product { get; set; }=string.Empty;
        public int TotalCount { get; set; }
    }
}
