using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class ComplaintResponse
    {
        public string Category { get; set; } = string.Empty;
        public int TotalCount { get; set; }
    }
}
