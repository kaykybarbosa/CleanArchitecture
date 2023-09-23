using CleanArchitecture.Application.DTOs.Requests.Product;
using CleanArchitecture.Application.DTOs.Responses.Product;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAll();
        Task<ProductResponse> GetById(int? id);

        Task Add(ProductRequest request);
        Task Update(ProductRequest request);
        Task Remove(int? id);
    }
}