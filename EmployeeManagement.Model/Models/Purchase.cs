
namespace EmployeeManagement.Model.Models
{
    public class Purchase
    {
        public string? CustomerId { get; set; }
        public double Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Month { get; set; }
        public string? Day { get; set; }
        public int TotalNo { get; set; }
    }
}
