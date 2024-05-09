using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EtitiyInterfaces;

namespace Repository.EntityRepositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Project project)
        {
            await _context.Project.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var result = await _context.Project.Include(x=>x.Organization).OrderByDescending(x => x.CreationDate).ToListAsync();
                return result;
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            var result =await _context.Project
                
               .Include(x => x.Organization).ThenInclude(x=>x.Beneficiaries).FirstOrDefaultAsync(p => p.Id == id);
            
            return result;
        }

        public async Task UpdateAsync(Project project)
        {
            var existingProject = await _context.Project
                
                .FirstOrDefaultAsync(p => p.Id == project.Id);

            if (existingProject != null)
            {
                _context.Entry(existingProject).CurrentValues.SetValues(project);
               
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateOrganizationAndAssignProject(Guid organizationId, Guid projectId)
        {
     
            var project = await _context.Project.FindAsync(projectId);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }

            // Assign the project to the organization
            project.OrganizationId = organizationId;
            
            _context.Entry(project).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

    }
}
