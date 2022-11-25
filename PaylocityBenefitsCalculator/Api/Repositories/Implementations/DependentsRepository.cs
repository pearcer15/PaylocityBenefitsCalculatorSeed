using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Implementations
{
    public class DependentsRepository : IDependentsRepository
    {
        public async Task<Dependent> GetDependentById(int id)
        {
            throw new NotImplementedException();
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
