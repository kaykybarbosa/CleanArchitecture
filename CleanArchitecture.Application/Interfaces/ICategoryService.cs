using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task Add(CategoryDTO request);
        Task Update(CategoryDTO request);
        Task Remove(int? id);
    }
}