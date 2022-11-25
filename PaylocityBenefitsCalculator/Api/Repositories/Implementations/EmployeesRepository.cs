using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Implementations
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public async Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEmployee(int Id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
