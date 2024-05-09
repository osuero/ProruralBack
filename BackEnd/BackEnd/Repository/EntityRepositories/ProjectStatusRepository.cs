using Data.Entities;
using Data;
using Repository.EtitiyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectStatus>> GetAllAsync()
        {
            return await _context.ProjectStatuses.ToListAsync();
        }
    }

}
