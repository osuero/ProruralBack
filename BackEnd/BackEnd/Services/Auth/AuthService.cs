using Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.AuthInterfaces;
using Services.AuthInterface;
using Services.SettingsModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IAuthRepository authRepository, IOptions<JwtSettings> jwtSettings)
        {
            _authRepository = authRepository;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<(bool IsSuccess, string Token, string UserId)> AuthenticateAsync(string username, string password)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null || !await _authRepository.ValidateCredentialsAsync(username, password))
            {
                return (false, null, null);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Suponiendo que `Id` es el `userId`
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (true, tokenHandler.WriteToken(token), user.Id.ToString());
        }
        public async Task<bool> IsEmailConfirmedAsync(string username)
        {
            return await _authRepository.IsEmailConfirmedAsync(username);
        }
        public async Task<bool> ChangePasswordAsync(string userId, string newPassword)
        {
            var hashPassword =  BCrypt.Net.BCrypt.HashPassword(newPassword);
            return await _authRepository.ChangePasswordAsync(userId, hashPassword);
        }
    }

}
