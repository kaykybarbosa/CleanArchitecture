using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int? id);

        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}