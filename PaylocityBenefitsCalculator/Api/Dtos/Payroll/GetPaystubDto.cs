using Api.Dtos.Dependent;
using Api.Dtos.Employee;

namespace Api.Dtos.Payroll
{
    public class GetPaystubDto
    {
        private GetEmployeeDto _employee;
        public decimal GrossWages { get; set; }
        public decimal BaseBenefits { get; private set; }
        public decimal DependentBenefits { get; private set; }
        public decimal HighWagePremium { get; private set;}
        public decimal SeniorPremium { get; private set;}
        public decimal NetWages { get; private set; }

        public GetPaystubDto(GetEmployeeDto employee)
        {
            _employee = employee;
            SetGrossWage();
            SetBaseBenefits();
            SetDependentBenefits();
            SetHighwagePremium();
            SetSeniorPremium();
            CalculateNetWages();
        }

        internal void SetGrossWage()
        {
            GrossWages = _employee.Salary / 26;
        }

        internal void SetBaseBenefits()
        {
            BaseBenefits = ((decimal)1000 * 12) / 26;
        }

        internal void SetDependentBenefits()
        {
            DependentBenefits = (_employee.Dependents.Count() * (decimal)600 * 12) / 26;
        }

        internal void SetHighwagePremium()
        {
            HighWagePremium = _employee.Salary > 80000 ? (_employee.Salary * (decimal).02) / 26 : 0;
        }

        internal void SetSeniorPremium()
        {
            decimal seniorPremium = 0;
            foreach (GetDependentDto dependent in _employee.Dependents)
            {
                int age = DateTime.Today.Year - dependent.DateOfBirth.Year;
                if (dependent.DateOfBirth.Month > DateTime.Today.Month || (dependent.DateOfBirth.Month == DateTime.Today.Month && dependent.DateOfBirth.Day > DateTime.Today.Day)) { age--; }
                if (age > 50) { seniorPremium += ((decimal)200 * 12 / 26); }
            }
            SeniorPremium = seniorPremium;
        }

        internal void CalculateNetWages()
        {
            NetWages = GrossWages - BaseBenefits - DependentBenefits - HighWagePremium - SeniorPremium;
        }

    }
}
