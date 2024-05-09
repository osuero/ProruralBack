using Data.Entities;
using Repository.EtitiyInterfaces;
using Services.EntityInterfaces;

namespace Services.EntityServices
{
    public class RubleService : IProductionCategoryService
    {
        private readonly IProductionCategoryRepository _rubleRepository;
        public RubleService(IProductionCategoryRepository rubleRepository)
        {
            _rubleRepository = rubleRepository;
        }

        public Task<IEnumerable<ProductionCategory>> GetAllProductionCategoryAsync() => _rubleRepository.GetAllProductionCategoryAsync();

        public Task<ProductionCategory> GetProductionCategoryByIdAsync(Guid id) => _rubleRepository.GetProductionCategoryByIdAsync(id);

        public Task CreateProductionCategoryAsync(ProductionCategory ruble) => _rubleRepository.CreateProductionCategoryAsync(ruble);

        public Task UpdateProductionCategoryAsync(ProductionCategory ruble) => _rubleRepository.UpdateProductionCategoryAsync(ruble);

        public Task DeleteProductionCategoryAsync(Guid id) => _rubleRepository.DeleteProductionCategoryAsync(id);
    }
}
