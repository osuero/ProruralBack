using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IProjectStatusService
    {
        Task<IEnumerable<ProjectStatus>> GetAllProjectStatusesAsync();
    }
}
