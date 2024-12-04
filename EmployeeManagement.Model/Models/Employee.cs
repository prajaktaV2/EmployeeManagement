
namespace EmployeeManagement.Model.Models
{
    public  class Employee
    {
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }

    }
}
