using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services
{
    public class EmployeesService
    {
        private IEmployeesRepository _employeesRepository;
        private IDependentsRepository _dependentsRepository;
        private DependentsService _dependentService;

        public EmployeesService(IEmployeesRepository employeesRepository, IDependentsRepository dependentsRepository, DependentsService dependentsService) { 
            _employeesRepository = employeesRepository;
            _dependentsRepository= dependentsRepository;
            _dependentService = dependentsService;
        }

        public async Task<GetEmployeeDto> GetEmployeeById(int id)
        {
            Employee employee = await _employeesRepository.GetEmployeeById(id);
            employee.Dependents = await _dependentService.GetDependentsByEmployeeId(id);
            return new GetEmployeeDto(employee);
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await _employeesRepository.GetAllEmployees();
            var tasks = employees.Select(async emp => emp.Dependents = await _dependentService.GetDependentsByEmployeeId(emp.Id)).ToList();
            await Task.WhenAll(tasks);
            return employees.Select(e => new GetEmployeeDto(e));
        }

        public async Task<IEnumerable<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
        {
            int newId = await _employeesRepository.GetNewEmployeeId();
            if (employee.Dependents != null && employee.Dependents.Count > 0)
            {
                Parallel.ForEach(employee.Dependents, dependent =>
                {
                    _dependentService.AddDependent(new AddDependentWithEmployeeIdDto(dependent, newId));
                });
            }
            if (await _employeesRepository.AddEmployee(new Employee(employee, newId)))
            {
                return new List<AddEmployeeDto> { employee };
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<GetEmployeeDto> UpdateEmployee(int Id, UpdateEmployeeDto employee)
        {
            Employee employeeToUpdate = await _employeesRepository.GetEmployeeById(Id);
            employeeToUpdate.UpdateEmployee(employee);
            if(await _employeesRepository.UpdateEmployee(Id, employeeToUpdate))
            {
                employeeToUpdate.Dependents = await _dependentService.GetDependentsByEmployeeId(Id);
                return new GetEmployeeDto(employeeToUpdate);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<GetEmployeeDto>> DeleteEmployee(int Id)
        {
            if(await _employeesRepository.DeleteEmployee(Id))
            {
                ICollection<Dependent> dependents = await _dependentService.GetDependentsByEmployeeId(Id);
                var tasks = dependents.Select(async d => await _dependentsRepository.DeleteDependent(d.Id));
                await Task.WhenAll(tasks);
                return await GetAllEmployees();
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
