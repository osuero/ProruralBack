using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;
using System.Collections.Generic;

namespace Services.EntityServices
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _repository;

        public BeneficiaryService(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Beneficiary beneficiary)
        {
            // Aquí puedes agregar cualquier lógica adicional antes de guardar
            await _repository.AddAsync(beneficiary);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Beneficiary>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Beneficiary> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Beneficiary>> GetNotAssigned()
        {
            return await _repository.GetNotAssigned();
        }

        public async Task UpdateAsync(Beneficiary beneficiary)
        {
            await _repository.UpdateAsync(beneficiary);
        }

        public async Task AssociateWithOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId) {

            await _repository.AssociateWithOrganizationAsync(beneficiaryIds, organizationId);
        }

        public async Task RemoveOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId)
        {
            await _repository.removeOrganizationAsync(beneficiaryIds, organizationId);
        }
    }
}
