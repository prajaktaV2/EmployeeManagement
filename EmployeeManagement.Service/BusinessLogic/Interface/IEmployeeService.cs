using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task AddEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(int id);
    }
}
