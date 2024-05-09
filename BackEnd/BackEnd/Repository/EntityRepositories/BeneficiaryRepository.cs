using Data.Entities;
using Data;
using Repository.EtitiyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityRepositories
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Beneficiary beneficiary)
        {
            await _context.Beneficiaries.AddAsync(beneficiary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary != null)
            {
                beneficiary.IsDeleted = true;
                _context.Beneficiaries.Update(beneficiary);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Beneficiary>> GetAllAsync()
        {
            return await _context.Beneficiaries.Include(x => x.Organization).Include(x=>x.IcvType).ToListAsync();
        }

        public async Task<Beneficiary> GetByIdAsync(Guid id)
        {
            return await _context.Beneficiaries.FindAsync(id);
        }

        public async Task<IEnumerable<Beneficiary>> GetNotAssigned()
        {
            var result =await _context.Beneficiaries.Include(x=>x.Organization).OrderByDescending(x => x.CreationDate).Where(b => b.OrganizationId == Guid.Empty || b.OrganizationId == null )
        .ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Beneficiary beneficiary)
        {
            _context.Beneficiaries.Update(beneficiary);
            await _context.SaveChangesAsync();
        }
        public async Task AssociateWithOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId)
        {
            var beneficiaries = await _context.Beneficiaries
                                              .Where(b => beneficiaryIds.Contains(b.Id) && (b.OrganizationId == null || b.OrganizationId == Guid.Empty)).OrderByDescending(x=>x.CreationDate)
                                              .ToListAsync();

            if (beneficiaries.Count > 0)
            {
                foreach (var beneficiary in beneficiaries)
                {
                    beneficiary.OrganizationId = organizationId;
                }

                _context.Beneficiaries.UpdateRange(beneficiaries);
                await _context.SaveChangesAsync();
            }
        }

        public async Task removeOrganizationAsync(IEnumerable<Guid> beneficiaryIds, Guid organizationId)
        {
            var beneficiaries = await _context.Beneficiaries
                                             .Where(b => beneficiaryIds.Contains(b.Id))
                                             .ToListAsync();

            if (beneficiaries.Count > 0)
            {
                foreach (var beneficiary in beneficiaries)
                {
                    beneficiary.OrganizationId = null;
                }

                _context.Beneficiaries.UpdateRange(beneficiaries);
                await _context.SaveChangesAsync();
            }
        }
    }
}
