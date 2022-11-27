using Api.Database;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Implementations
{
    public class DependentsRepository : IDependentsRepository
    {
        private DependentsTable _dependentsTable;
        private DependentEmployeeJoinTable _joinTable;
        
        public DependentsRepository(DependentsTable dependentsTable, DependentEmployeeJoinTable joinTable) {
            _dependentsTable = dependentsTable;
            _joinTable = joinTable;
        }
        
        public async Task<Dependent> GetDependentById(int id)
        {
            return _dependentsTable.dependents.FirstOrDefault(d => d.Id == id);
        }

        public async Task<IEnumerable<Dependent>> GetAllDependents()
        {
            return _dependentsTable.dependents;
        }

        public async Task<bool> AddDependent(Dependent dependent)
        {
            try
            {
                _dependentsTable.dependents = _dependentsTable.dependents.Concat(new List<Dependent> { dependent });
                _joinTable.dependentEmployee.Add(dependent.Id, dependent.EmployeeId); //ToDo: should this be tryadd?
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateDependent(int Id, Dependent dependent)
        {
            try
            {
                _dependentsTable.dependents.Where(dep => dep.Id == Id).Select(d =>
                {
                    d.FirstName = dependent.FirstName;
                    d.LastName = dependent.LastName;
                    d.DateOfBirth = dependent.DateOfBirth;
                    d.Relationship = dependent.Relationship;
                    return d;
                });
                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDependent(int Id)
        {
            _dependentsTable.dependents = _dependentsTable.dependents.Where(d => d.Id != Id);
            bool join = _joinTable.dependentEmployee.ContainsKey(Id) ? _joinTable.dependentEmployee.Remove(Id) : true;
            return join && !_dependentsTable.dependents.Any(d => d.Id == Id);
        }

        public async Task<IEnumerable<int>> GetDependentIds(int EmployeeId)
        {
            return _joinTable.dependentEmployee.Where(kvp => kvp.Value == EmployeeId).Select(kvp => kvp.Key).ToList();
        }

        public async Task<int> GetNewDependentId()
        {
            return _dependentsTable.dependents.Max(d => d.Id) + 1;
        }

        public async Task<int> GetEmployeeIdForDependent(int id)
        {
            return _joinTable.dependentEmployee[id];
        }
    }
}
