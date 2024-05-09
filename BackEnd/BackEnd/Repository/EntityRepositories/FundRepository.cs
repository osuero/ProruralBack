using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EtitiyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityRepositories
{
    public class FundRepository : IFundRepository
    {
        private readonly ApplicationDbContext _context;

        public FundRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fund> GetByIdAsync(Guid id)
        {
            return await _context.Funds
                .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
        }

        public async Task<IEnumerable<Fund>> GetAllAsync()
        {
            return await _context.Funds
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public async Task AddAsync(Fund fund)
        {
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fund fund)
        {
            _context.Entry(fund).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var fund = await _context.Funds.FindAsync(id);
            if (fund != null)
            {
                fund.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Fund>> GetByProjectIdAsync(Guid projectId)
        {
            return await _context.Funds
                                 .Where(f => f.ProjectId == projectId)
                                 .ToListAsync();
        }
    }
}
