using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task AddAsync(Project project)
        {
            await _projectRepository.AddAsync(project);
        }

        public async Task UpdateAsync(Project project)
        {
            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }

        public async Task UpdateOrganizationAndAssignProject(Guid organizationId, Guid projectId)
        {
            await _projectRepository.UpdateOrganizationAndAssignProject(organizationId, projectId);
        }
    }
}
