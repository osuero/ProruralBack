using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> GetByIdAsync(Guid id);
        Task<IEnumerable<Beneficiary>> GetAllAsync();
        Task<IEnumerable<Beneficiary>> GetNotAssigned();
        Task AddAsync(Beneficiary beneficiary);
        Task UpdateAsync(Beneficiary beneficiary);
        Task DeleteAsync(Guid id);
        Task AssociateWithOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId);

        Task removeOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId);
    }
}
