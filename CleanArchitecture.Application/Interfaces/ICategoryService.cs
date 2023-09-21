using CleanArchitecture.Application.DTOs.Requests.Category;
using CleanArchitecture.Application.DTOs.Responses.Category;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetCategories();
        Task<CategoryResponse> GetById(int? id);
        Task Add(CategoryRequest request);
        Task Update(CategoryRequest request);
        Task Remove(int? id);
    }
}