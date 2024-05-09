using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid id);
        Task UpdateOrganizationAndAssignProject(Guid organizationId, Guid projectId);
    }
}
