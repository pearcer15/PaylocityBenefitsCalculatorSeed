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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetDependentDto>> GetAllDependents()
        {
            throw new NotImplementedException();
        }

        public async Task<AddDependentWithEmployeeIdDto> AddDependent(AddDependentWithEmployeeIdDto dependent)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDependentDto> UpdateDependent(int Id, UpdateDependentDto dependent)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetDependentDto>> DeleteDependent(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
