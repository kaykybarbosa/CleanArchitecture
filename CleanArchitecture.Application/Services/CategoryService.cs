using AutoMapper;
using CleanArchitecture.Application.DTOs.Requests.Category;
using CleanArchitecture.Application.DTOs.Responses.Category;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories); 
        }

        public async Task<CategoryResponse> GetById(int? id)
        {
            var category = await _repository.GetById(id);
            return _mapper.Map<CategoryResponse>(category);
        }

        public async Task Add(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.Create(category);
        }

        public async Task Update(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.Update(category);
        }

        public async Task Remove(int? id)
        {
            var category = await _repository.GetById(id);
            await _repository.Remove(category);
        }
    }
}