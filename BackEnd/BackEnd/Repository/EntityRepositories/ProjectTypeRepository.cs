using Data.Entities;
using Data;
using Repository.EtitiyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepositories
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectType>> GetAllAsync()
        {
            var result = await _context.ProjectType.ToListAsync();
            return result;
        }
    }
}
