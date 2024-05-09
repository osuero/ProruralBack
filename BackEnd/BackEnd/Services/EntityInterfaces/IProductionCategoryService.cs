using Data.Entities;

namespace Services.EntityInterfaces
{
    public interface IProductionCategoryService
    {
        Task<IEnumerable<ProductionCategory>> GetAllProductionCategoryAsync();
        Task<ProductionCategory> GetProductionCategoryByIdAsync(Guid id);
        Task CreateProductionCategoryAsync(ProductionCategory rublo);
        Task UpdateProductionCategoryAsync(ProductionCategory rublo);
        Task DeleteProductionCategoryAsync(Guid id);
    }
}
