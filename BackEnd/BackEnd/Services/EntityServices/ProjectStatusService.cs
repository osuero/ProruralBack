using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class ProjectStatusService : IProjectStatusService
    {
        private readonly IProjectStatusRepository _projectStatusRepository;

        public ProjectStatusService(IProjectStatusRepository projectStatusRepository)
        {
            _projectStatusRepository = projectStatusRepository;
        }

        public async Task<IEnumerable<ProjectStatus>> GetAllProjectStatusesAsync()
        {
            // Here, additional business logic can be applied if necessary
            return await _projectStatusRepository.GetAllAsync();
        }
    }
}
