using Data.Entities;

namespace Repository.AuthInterfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<bool> IsEmailConfirmedAsync(string username);
        Task<bool> ChangePasswordAsync(string userId, string newPassword);
    }
}
