using Api.Dtos.Employee;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services
{
    public class EmployeesService
    {
        private IEmployeesRepository _employeesRepository;
        private IDependentsRepository _dependentsRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IDependentsRepository dependentsRepository) { 
            _employeesRepository = employeesRepository;
            _dependentsRepository= dependentsRepository;
        }

        public async Task<GetEmployeeDto> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await _employeesRepository.GetAllEmployees();
            var tasks = employees.Select(async emp => emp.Dependents = await GetDependents(emp.Id)).ToList();
            await Task.WhenAll(tasks);
            return employees.Select(e => new GetEmployeeDto(e));
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

        private async Task<ICollection<Dependent>> GetDependents(int EmployeeId) {
            IEnumerable<int> dependentIds = await _employeesRepository.GetDependentIds(EmployeeId);
            ICollection<Task<Dependent>> dependentTask = dependentIds.Select(id => _dependentsRepository.GetDependentById(id)).ToList();
            return await Task.WhenAll(dependentTask);
        }
    }
}
