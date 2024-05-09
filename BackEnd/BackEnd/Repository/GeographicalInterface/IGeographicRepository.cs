using Data.Geographical;

namespace Repository.GeographicalInterface
{
    public interface IGeographicRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
