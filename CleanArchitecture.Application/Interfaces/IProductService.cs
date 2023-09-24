using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int? id);

        Task Add(ProductDTO request);
        Task Update(ProductDTO request);
        Task Remove(int? id);
    }
}