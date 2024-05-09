using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IProjectStatusRepository
    {
        Task<IEnumerable<ProjectStatus>> GetAllAsync();
    }
}
