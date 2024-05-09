using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class IcvService : IIcvService
    {
        private readonly IicvRepository _icvRepository;

        public IcvService(IicvRepository icvRepository)
        {
            _icvRepository = icvRepository;
        }

        public async Task<IEnumerable<IcvTypes>> GetAllIcvTypesAsync()
        {
            return await _icvRepository.GetAllAsync();
        }
    }
}
