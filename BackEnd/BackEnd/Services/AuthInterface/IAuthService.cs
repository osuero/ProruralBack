namespace Services.AuthInterface
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, string Token, string UserId)> AuthenticateAsync(string username, string password);
        Task<bool> IsEmailConfirmedAsync(string username);
        Task<bool> ChangePasswordAsync(string userId, string newPassword);
    }
}
