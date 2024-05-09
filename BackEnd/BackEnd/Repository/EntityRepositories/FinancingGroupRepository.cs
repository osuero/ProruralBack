using Data.Entities;
using Data;
using Repository.EtitiyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepositories
{
    public class FinancingGroupRepository: IFinancingGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public FinancingGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FinancingGroup financingGroup)
        {
            await _context.FinancingGroup.AddAsync(financingGroup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var financingGroup = await _context.FinancingGroup.FindAsync(id);
            if (financingGroup != null)
            {
                _context.FinancingGroup.Remove(financingGroup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FinancingGroup>> GetAllAsync()
        {
            return await _context.FinancingGroup.ToListAsync();
        }

        public async Task<FinancingGroup> GetByIdAsync(Guid id)
        {
            return await _context.FinancingGroup
                .FirstOrDefaultAsync(fg => fg.Id == id);
        }

        public async Task UpdateAsync(FinancingGroup financingGroup)
        {
            var existingFinancingGroup = await _context.FinancingGroup
                .FirstOrDefaultAsync(fg => fg.Id == financingGroup.Id);

            if (existingFinancingGroup != null)
            {
                _context.Entry(existingFinancingGroup).CurrentValues.SetValues(financingGroup);
                await _context.SaveChangesAsync();
            }
        }
    }
    
}
