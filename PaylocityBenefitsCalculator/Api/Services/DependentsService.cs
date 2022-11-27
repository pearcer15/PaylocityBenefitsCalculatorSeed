using Api.Dtos.Dependent;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services
{
    public class DependentsService
    {
        private IDependentsRepository _dependentsRepository;

        public DependentsService (IDependentsRepository dependentsRepository)
        {
            _dependentsRepository = dependentsRepository;
        }

        public async Task<GetDependentDto> GetDependentById(int id)
        {
            Dependent dependent = await _dependentsRepository.GetDependentById(id);
            return new GetDependentDto(dependent);
        }

        public async Task<IEnumerable<GetDependentDto>> GetAllDependents()
        {
            IEnumerable<Dependent> dependents =  await _dependentsRepository.GetAllDependents();
            return dependents.Select(d => new GetDependentDto(d));
        }

        public async Task<IEnumerable<AddDependentWithEmployeeIdDto>> AddDependent(AddDependentWithEmployeeIdDto dependent)
        {
            if (await DependentRelationshipAllowed(dependent.Relationship, dependent.EmployeeId))
            {
                int newId = await _dependentsRepository.GetNewDependentId();
                if (await _dependentsRepository.AddDependent(new Dependent(dependent, newId)))
                {
                    return new List<AddDependentWithEmployeeIdDto> { dependent };
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<GetDependentDto> UpdateDependent(int Id, UpdateDependentDto dependent)
        {
            Dependent dependentToUpdate = await _dependentsRepository.GetDependentById(Id);
            dependentToUpdate.EmployeeId = await GetEmployeeIdForDependent(dependentToUpdate.Id);
            if (await DependentRelationshipAllowed(dependent.Relationship, dependentToUpdate.EmployeeId))
            {
                dependentToUpdate.UpdateDependent(dependent);
                if (await _dependentsRepository.UpdateDependent(Id, dependentToUpdate))
                {
                    return new GetDependentDto(dependentToUpdate);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        private async Task<int> GetEmployeeIdForDependent(int id)
        {
            return await _dependentsRepository.GetEmployeeIdForDependent(id);
        }

        public async Task<IEnumerable<GetDependentDto>> DeleteDependent(int Id)
        {
            if (await _dependentsRepository.DeleteDependent(Id))
            {
                return await GetAllDependents();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<bool> DependentRelationshipAllowed(Relationship relationship, int employeeId)
        {
           if (relationship == Relationship.Child) { return true; }
           else if (relationship == Relationship.None) { return false; }
           else {
                ICollection<Dependent> dependents = await GetDependentsByEmployeeId(employeeId);
                return dependents?.Count > 0 ? !dependents.Any(d => d.Relationship == Relationship.DomesticPartner || d.Relationship == Relationship.Spouse) : true;
           }
        }

        public async Task<ICollection<Dependent>> GetDependentsByEmployeeId(int employeeId)
        {
            IEnumerable<int> dependentIds = await _dependentsRepository.GetDependentIds(employeeId);
            var dependentTask = dependentIds.Select(id => _dependentsRepository.GetDependentById(id)).ToList();
            ICollection<Dependent> dependents = await Task.WhenAll(dependentTask);
            dependents.ToList().ForEach(d => d.EmployeeId = employeeId);
            return dependents;
        }
    }
}
