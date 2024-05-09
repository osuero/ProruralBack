using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IFundRepository
    {
        Task<Fund> GetByIdAsync(Guid id);
        Task<IEnumerable<Fund>> GetAllAsync();
        Task AddAsync(Fund fund);
        Task UpdateAsync(Fund fund);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Fund>> GetByProjectIdAsync(Guid projectId);
    }
}
