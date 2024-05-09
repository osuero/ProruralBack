using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IProjectService
    {
        Task<Project> GetByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid id);
        Task UpdateOrganizationAndAssignProject(Guid organizationId, Guid projectId);
    }
}
