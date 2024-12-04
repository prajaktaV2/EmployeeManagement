

namespace EmployeeManagement.Model.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public Product(string productId, string name, double price, string category)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
