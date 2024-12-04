using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class OrderPurchaseViewModel
    {
        public string? OrderId { get; set; }
        public string? CustomerId { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public DateTime PurchaseDate { get; set; }


    }
}
