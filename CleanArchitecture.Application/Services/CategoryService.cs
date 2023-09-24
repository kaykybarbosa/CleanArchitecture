using AutoMapper;
using CleanArchitecture.Application.DTOs;
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

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories); 
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await _repository.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Add(CategoryDTO request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.Create(category);
        }

        public async Task Update(CategoryDTO request)
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