using Api.Database;
using Api.Models;
using Api.Repositories.Interfaces;
using System.Linq;

namespace Api.Repositories.Implementations
{
    public class DependentsRepository : IDependentsRepository
    {
        private DependentsTable _dependentsTable;
        
        public DependentsRepository(DependentsTable dependentsTable) {
            _dependentsTable = dependentsTable;
        }
        
        public async Task<Dependent> GetDependentById(int id)
        {
            return _dependentsTable.dependents.FirstOrDefault(d => d.Id == id);
        }

        public async Task<IEnumerable<Dependent>> GetAllDependents()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddDependent(int EmployeeId, Dependent dependent)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDependent(int Id, Dependent dependent)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDependent(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
