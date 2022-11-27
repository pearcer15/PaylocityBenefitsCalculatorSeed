using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IDependentsRepository
    {
        Task<Dependent> GetDependentById(int id);
        Task<IEnumerable<Dependent>> GetAllDependents();
        Task<bool> AddDependent(Dependent dependent);
        Task<bool> UpdateDependent(int Id, Dependent dependent);
        Task<bool> DeleteDependent(int Id);
        Task<IEnumerable<int>> GetDependentIds(int EmployeeId);
        Task<int> GetNewDependentId();
        Task<int> GetEmployeeIdForDependent(int Id);
    }
}
