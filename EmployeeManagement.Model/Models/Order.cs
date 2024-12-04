using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(string orderId, string customerId, List<Product> products, DateTime orderDate)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Products = products;
            OrderDate = orderDate;
        }
    }
}
