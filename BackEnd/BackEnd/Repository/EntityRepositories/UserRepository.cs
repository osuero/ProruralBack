using Data.Entities;
using Data;
using Repository.EtitiyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        { 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null && !user.IsDeleted)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                       .OrderByDescending(u => u.CreationDate)  // Ordena de más reciente a más antiguo
                       .ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task UpdateAsync(User user)
        {
            user.UpdatedDate = DateTime.UtcNow;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<bool> ChangePasswordAsync(string userId, string newPassword)
        {
            var user = await _context.Set<User>().FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.PasswordHash = newPassword; // Considera utilizar hashing para la contraseña
            _context.Set<User>().Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
