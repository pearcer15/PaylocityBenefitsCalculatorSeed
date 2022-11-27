using Api.Dtos.Employee;

namespace Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

        public Employee() { }

        public Employee(AddEmployeeDto newEmployee, int id)
        {
            Id = id;
            FirstName = newEmployee.FirstName;
            LastName = newEmployee.LastName;
            Salary = newEmployee.Salary;
            DateOfBirth = newEmployee.DateOfBirth;
        }

        public Employee UpdateEmployee(UpdateEmployeeDto update)
        {
            FirstName = update.FirstName ?? FirstName;
            LastName = update.LastName ?? LastName;
            Salary = update.Salary;

            return this;
        }
    }
}
