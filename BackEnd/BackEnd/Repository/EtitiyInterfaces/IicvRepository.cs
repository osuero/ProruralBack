using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IicvRepository
    {
        Task<IEnumerable<IcvTypes>> GetAllAsync();
    }
}
