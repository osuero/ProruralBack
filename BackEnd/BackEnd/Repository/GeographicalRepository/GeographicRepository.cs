using Data;
using Data.Geographical;
using Microsoft.EntityFrameworkCore;
using Repository.GeographicalInterface;

namespace Repository.GeographicalRepository
{
    public class GeographicRepository : IGeographicRepository
    {
        private readonly ApplicationDbContext _context;

        public GeographicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions
                    .Include(r => r.Provinces)
                        .ThenInclude(p => p.Municipalities)
                            .ThenInclude(m => m.Sections)
                                .ThenInclude(s => s.Places)
                    .ToListAsync();
        }
    }
}
