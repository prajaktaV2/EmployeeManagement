using System;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Data.DataList
{
    public static class EmployeeData
    {
        public static List<Employee> employee = new List<Employee>()
        {
            new Employee { EmpId = 1, FirstName = "John", LastName = "Doe",City="Thane", Designation = "Manager",Department="Marketing", Salary = 50000 },
            new Employee { EmpId = 2, FirstName = "Jane", LastName = "Smith",City="Mumbai", Designation = "Developer",Department="IT", Salary = 40000 },
            new Employee { EmpId = 3, FirstName = "Alice", LastName = "Johnson",City="Navi Mumbai", Designation = "HR Executive",Department="HR", Salary = 45000 }
        };
        
    }
}
