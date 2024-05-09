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
    public class IcvRepository: IicvRepository
    {
        private readonly ApplicationDbContext _context;
        public IcvRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IcvTypes>> GetAllAsync()
        {
          return await _context.IcvTypes.ToListAsync(); 
        }
    }
}
