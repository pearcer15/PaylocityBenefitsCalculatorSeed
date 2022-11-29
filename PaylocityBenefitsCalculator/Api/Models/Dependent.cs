using Api.Dtos.Dependent;

namespace Api.Models
{
    public class Dependent
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Relationship Relationship { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public Dependent() { }

        public Dependent(AddDependentWithEmployeeIdDto newDependent, int dependentId)
        {
            Id = dependentId;
            FirstName = newDependent.FirstName;
            LastName = newDependent.LastName;
            DateOfBirth = newDependent.DateOfBirth;
            Relationship = newDependent.Relationship;
            EmployeeId = newDependent.EmployeeId;
        }

        public Dependent UpdateDependent(UpdateDependentDto update)
        {
            FirstName = update.FirstName ?? FirstName;
            LastName = update.LastName ?? LastName;
            DateOfBirth = update.DateOfBirth;
            Relationship = update.Relationship;

            return this;
        }
    }
}
