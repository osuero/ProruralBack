using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IFundService
    {
        Task<Fund> GetByIdAsync(Guid id);
        Task<IEnumerable<Fund>> GetAllAsync();
        Task AddAsync(Fund fund);
        Task UpdateAsync(Fund fund);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Fund>> GetFundsByProjectId(Guid projectId);
    }
}
