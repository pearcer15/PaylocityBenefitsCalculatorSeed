namespace Api.Dtos.Dependent
{
    public class AddDependentWithEmployeeIdDto : AddDependentDto
    {
        public int EmployeeId { get; set; }

        public AddDependentWithEmployeeIdDto() { }

        public AddDependentWithEmployeeIdDto(AddDependentDto addDependentDto, int employeeId) { 
            FirstName = addDependentDto.FirstName;
            LastName = addDependentDto.LastName;
            DateOfBirth = addDependentDto.DateOfBirth;
            Relationship = addDependentDto.Relationship;
            EmployeeId = employeeId;
        }
    }
}
