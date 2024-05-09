using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class FinancingGroupService : IFinancingGroupService
    {
        private readonly IFinancingGroupRepository _financingGroupRepository;

        public FinancingGroupService(IFinancingGroupRepository financingGroupRepository)
        {
            _financingGroupRepository = financingGroupRepository;
        }

        public async Task AddFinancingGroupAsync(FinancingGroup financingGroup)
        {
            await _financingGroupRepository.AddAsync(financingGroup);
        }

        public async Task DeleteFinancingGroupAsync(Guid id)
        {
            await _financingGroupRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FinancingGroup>> GetAllFinancingGroupsAsync()
        {
            return await _financingGroupRepository.GetAllAsync();
        }

        public async Task<FinancingGroup> GetFinancingGroupByIdAsync(Guid id)
        {
            return await _financingGroupRepository.GetByIdAsync(id);
        }

        public async Task UpdateFinancingGroupAsync(FinancingGroup financingGroup)
        {
            await _financingGroupRepository.UpdateAsync(financingGroup);
        }
    }
}
