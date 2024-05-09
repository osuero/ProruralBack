using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IFinancingGroupRepository
    {
        Task<FinancingGroup> GetByIdAsync(Guid id);
        Task<IEnumerable<FinancingGroup>> GetAllAsync();
        Task AddAsync(FinancingGroup financingGroup);
        Task UpdateAsync(FinancingGroup financingGroup);
        Task DeleteAsync(Guid id);
    }
}
