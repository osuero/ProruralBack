using Data.Geographical;
using Repository.GeographicalInterface;
using Services.GeographicalInterface;

namespace Services.GeographicalsServices
{
    public class GeographicalService: IGeographicalService
    {
        private readonly IGeographicRepository _geoRepository;

        public GeographicalService(IGeographicRepository geoRepository)
        {
            _geoRepository = geoRepository;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _geoRepository.GetAllAsync();
        }
    }
    
}
