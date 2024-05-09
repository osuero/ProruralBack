using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IProjectTypeService
    {
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
    }
}
