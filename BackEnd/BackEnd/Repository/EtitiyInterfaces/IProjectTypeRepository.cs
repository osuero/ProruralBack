using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IProjectTypeRepository
    {
        Task<IEnumerable<ProjectType>> GetAllAsync();
    }
}
