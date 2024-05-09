using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IIcvService
    {
        Task<IEnumerable<IcvTypes>> GetAllIcvTypesAsync();
    }
}
