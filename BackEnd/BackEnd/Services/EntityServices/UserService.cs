using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<string> GenerateUniqueUsername(string firstName, string lastName)
    {
        var baseUsername = $"{firstName[0]}{lastName}".ToLower();
        if (!await UsernameExists(baseUsername))
        {
            return baseUsername;
        }

        baseUsername = $"{firstName.Substring(0, 2)}{lastName}".ToLower();
        if (!await UsernameExists(baseUsername))
        {
            return baseUsername;
        }

        baseUsername = $"{firstName.Substring(0, 3)}{lastName}".ToLower();
        if (!await UsernameExists(baseUsername))
        {
            return baseUsername;
        }

        // Extend with additional rules as needed

        throw new Exception("Unable to generate a unique username");
    }

    public async Task<bool> UsernameExists(string username)
    {
        var user = await _userRepository.FindByUsernameAsync(username);
        return user != null;
    }


}
