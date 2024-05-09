using Data.Entities;
using Data;
using Repository.AuthInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.AuthRepositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user == null) return false;
            
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
        public async Task<bool> IsEmailConfirmedAsync(string username)
        {
            User user = await GetUserByUsernameAsync(username);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return user.IsEmailConfirmed;
        }

        public async Task<bool> ChangePasswordAsync(string userId, string newPassword)
        {
            if (!Guid.TryParse(userId, out Guid userGuid))
            {
                return false; // Retorna falso si userId no se puede convertir a Guid
            }

            var user = await _context.Set<User>().FindAsync(userGuid);
            if (user == null)
            {
                return false; // Retorna falso si no se encuentra un usuario con ese Guid
            }
            //user.IsEmailConfirmed = true;
            user.PasswordHash = newPassword; // Asegúrate de hashear la contraseña antes de guardarla
            _context.Set<User>().Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }

}
