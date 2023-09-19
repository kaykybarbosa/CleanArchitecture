using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAync();
        Task<Product> GetProductByIdAync(int? id);
        Task<Product> GetProductCategoryAync(int? id);

        Task<Product> CreateAync(Product Product);
        Task<Product> UpdateAync(Product Product);
        Task<Product> RemoveAync(Product Product);
    }
}
