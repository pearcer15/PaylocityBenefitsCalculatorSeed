using Api.Database;
using Api.Models;
using Api.Repositories.Interfaces;
using System.Linq;

namespace Api.Repositories.Implementations
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private EmployeesTable _employeesTable;
        private DependentEmployeeJoinTable _joinTable;

        public EmployeesRepository(EmployeesTable employeesTable, DependentEmployeeJoinTable dependentEmployeeJoinTable)
        {
            _employeesTable = employeesTable;
            _joinTable = dependentEmployeeJoinTable;
        }
        
        public async Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return _employeesTable.employees;
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

        public async Task<IEnumerable<int>> GetDependentIds(int EmployeeId)
        {
            return _joinTable.dependentEmployee.Where(kvp => kvp.Value == EmployeeId).Select(kvp => kvp.Key).ToList();
        }
    }
}
