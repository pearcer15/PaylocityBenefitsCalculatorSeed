using Api.Dtos.Employee;
using Api.Models;
using Api.Repositories.Implementations;
using Api.Repositories.Interfaces;

namespace Api.Services
{
    public class EmployeesService
    {
        private IEmployeesRepository _employeesRepository;

        public EmployeesService() { 
            _employeesRepository = new EmployeesRepository();
        }

        public async Task<GetEmployeeDto> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public async Task<GetEmployeeDto> UpdateEmployee(int Id, UpdateEmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetEmployeeDto>> DeleteEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Dependent> GetDependents(int EmployeeId) { 
            throw new NotImplementedException();
        }
    }
}
