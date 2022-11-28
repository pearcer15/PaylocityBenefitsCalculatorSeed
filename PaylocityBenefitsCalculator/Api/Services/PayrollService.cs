using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Dtos.Payroll;

namespace Api.Services
{
    public class PayrollService
    {
        private EmployeesService _employeesService;

        public PayrollService(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task<GetPaystubDto> GetPaystub(int id)
        {
            return new GetPaystubDto(await _employeesService.GetEmployeeById(id)).SetBaseBenefits().SetDependentBenefits().SetHighwagePremium().SetSeniorPremium().CalculateNetWages();
        }
    }
}
