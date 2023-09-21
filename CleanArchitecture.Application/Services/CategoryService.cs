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
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories); 
        }

        public async Task<CategoryResponse> GetById(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryResponse>(category);
        }

        public async Task Add(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.Create(category);
        }

        public async Task Update(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.Update(category);
        }

        public async Task Remove(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            await _categoryRepository.Remove(category);
        }
    }
}