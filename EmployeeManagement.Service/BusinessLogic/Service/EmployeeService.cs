using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class EmployeeService : IEmployeeService
    {
        public Task AddEmployeeAsync(Employee employee)
        {
            employee.EmpId = EmployeeData.employee.Max(e => e.EmpId) + 1;
            EmployeeData.employee.Add(employee);
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            var employee = EmployeeData.employee.FirstOrDefault(e => e.EmpId == id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            EmployeeData.employee.Remove(employee);
            return Task.CompletedTask;
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(EmployeeData.employee.ToList());
        }

        public Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return Task.FromResult(EmployeeData.employee.Where(e => e.EmpId == id).FirstOrDefault());
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            //throw new Exception("Error");
            var existingEmployee = EmployeeData.employee.FirstOrDefault(e => e.EmpId == employee.EmpId);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.City = employee.City;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {employee.EmpId} not found.");
            }
            return Task.CompletedTask;
        }
    }
}
