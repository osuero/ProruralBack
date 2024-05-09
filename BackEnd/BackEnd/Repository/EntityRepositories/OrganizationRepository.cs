using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EtitiyInterfaces;


namespace Repository.EntityRepositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await _context.Organizations
                .Include(x=>x.Beneficiaries)
                .Include(x=>x.President)
                .Include(x=>x.Region)
                .Include(x=>x.Province)
                .Where(o => !o.IsDeleted).OrderByDescending(x => x.CreationDate)
                .ToListAsync();
        }

        public async Task<Organization> GetByIdAsync(Guid id)
        {
            var result = await _context.Organizations
                .Include(x => x.Beneficiaries)
                .Include(x => x.President)
                .Include(x => x.Region)
                .Include(x => x.Province)
                .Where(o => !o.IsDeleted)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
            return result;
        }

        public async Task AddAsync(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                organization.IsDeleted = true;
                _context.Organizations.Update(organization);
                await _context.SaveChangesAsync();
            }
        }
    }
}
