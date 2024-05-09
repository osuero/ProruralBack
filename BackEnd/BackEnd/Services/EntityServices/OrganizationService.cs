using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _repository;

        public OrganizationService(IOrganizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Organization> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Organization organization)
        {
            await _repository.AddAsync(organization);
        }

        public async Task UpdateAsync(Organization organization)
        {
            await _repository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
