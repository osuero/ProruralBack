using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class FundService : IFundService  // Explicitly implement the interface
    {
        private readonly IFundRepository _fundRepository;

        public FundService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public Task<Fund> GetByIdAsync(Guid id) => _fundRepository.GetByIdAsync(id);

        public Task<IEnumerable<Fund>> GetAllAsync() => _fundRepository.GetAllAsync();

        public Task AddAsync(Fund fund) => _fundRepository.AddAsync(fund);

        public Task UpdateAsync(Fund fund) => _fundRepository.UpdateAsync(fund);

        public Task DeleteAsync(Guid id) => _fundRepository.DeleteAsync(id);

        public Task<IEnumerable<Fund>> GetFundsByProjectId(Guid projectId)
        {
           var result = _fundRepository.GetByProjectIdAsync(projectId);
            return result;
        }
    }
}
