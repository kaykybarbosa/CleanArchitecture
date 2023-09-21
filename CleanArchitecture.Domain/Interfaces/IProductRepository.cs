using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}