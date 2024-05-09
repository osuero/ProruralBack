using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EtitiyInterfaces;

namespace Repository.EntityRepositories
{
    public class ProductionCategoryRepository: IProductionCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductionCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductionCategory>> GetAllProductionCategoryAsync()
        {
            return await _context.ProductionCategories.OrderByDescending(x=>x).ToListAsync();
        }

        public async Task<ProductionCategory> GetProductionCategoryByIdAsync(Guid id)
        {
            return await _context.ProductionCategories.FindAsync(id);
        }

        public async Task CreateProductionCategoryAsync(ProductionCategory category)
        {
            _context.ProductionCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductionCategoryAsync(ProductionCategory category)
        {
            _context.ProductionCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductionCategoryAsync(Guid id)
        {
            var category = await _context.ProductionCategories.FindAsync(id);
            category.IsDeleted = true;
            _context.ProductionCategories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
