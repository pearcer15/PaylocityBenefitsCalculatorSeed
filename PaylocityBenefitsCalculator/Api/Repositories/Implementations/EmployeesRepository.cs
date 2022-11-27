using Api.Database;
using Api.Models;
using Api.Repositories.Interfaces;

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
            return _employeesTable.employees.FirstOrDefault(emp => emp.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return _employeesTable.employees;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                _employeesTable.employees = _employeesTable.employees.Concat(new List<Employee> { employee });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(int Id, Employee employee)
        {
            try
            {
                _employeesTable.employees.Where(emp => emp.Id == Id).Select(e =>
                {
                    e.FirstName = employee.FirstName;
                    e.LastName = employee.LastName;
                    e.Salary = employee.Salary;
                    return e;
                });
                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            _employeesTable.employees = _employeesTable.employees.Where(_emp => _emp.Id != Id);
            return !_employeesTable.employees.Any(emp => emp.Id == Id);
        }

        public async Task<int> GetNewEmployeeId()
        {
            return _employeesTable.employees.Max(emp => emp.Id) + 1;
        }
    }
}
