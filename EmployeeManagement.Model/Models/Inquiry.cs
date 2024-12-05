using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class Inquiry
    {
        public string? CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime InquiryDate { get; set; }
        public int TotalNoOfInquiry { get; set; }

    }
}
