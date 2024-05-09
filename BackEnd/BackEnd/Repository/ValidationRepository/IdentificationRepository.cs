using Data;
using Microsoft.EntityFrameworkCore;
using Repository.ValidationInterface;

namespace Repository.ValidationRepository
{
    public class IdentificationRepository: IidentificationRepository
    { 
        private readonly ApplicationDbContext _context;

        public IdentificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateExist(string id)
        {
            var result = await _context.Beneficiaries.FirstOrDefaultAsync(x => x.IdentificationNumber == id);

            return result != null;
        }
    }
}
