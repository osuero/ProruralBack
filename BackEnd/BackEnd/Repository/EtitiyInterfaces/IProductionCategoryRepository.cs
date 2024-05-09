using Data.Entities;

namespace Repository.EtitiyInterfaces
{
    public interface IProductionCategoryRepository
    {
        Task<IEnumerable<ProductionCategory>> GetAllProductionCategoryAsync();
        Task<ProductionCategory> GetProductionCategoryByIdAsync(Guid id);
        Task CreateProductionCategoryAsync(ProductionCategory rublo);
        Task UpdateProductionCategoryAsync(ProductionCategory rublo);
        Task DeleteProductionCategoryAsync(Guid id);
    }
}
