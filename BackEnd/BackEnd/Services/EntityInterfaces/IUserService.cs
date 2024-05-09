using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<string> GenerateUniqueUsername(string firstName, string lastName);
        Task<bool> UsernameExists(string username);
    }
}
