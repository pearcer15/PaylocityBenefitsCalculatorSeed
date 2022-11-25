using Api.Dtos.Employee;
using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(int Id, Employee employee);
        Task<bool> DeleteEmployee(int Id);
    }
}
