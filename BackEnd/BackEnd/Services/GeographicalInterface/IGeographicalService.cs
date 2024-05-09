using Data.Geographical;

namespace Services.GeographicalInterface
{
    public interface IGeographicalService
    {
        public Task<IEnumerable<Region>> GetAllRegionsAsync();
    }
}
