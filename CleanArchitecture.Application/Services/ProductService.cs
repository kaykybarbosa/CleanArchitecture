using AutoMapper;
using CleanArchitecture.Application.DTOs.Requests.Product;
using CleanArchitecture.Application.DTOs.Responses.Product;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<ProductResponse> GetById(int? id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> GetCategory(int? id)
        {
            var product = await _repository.GetCategoryAsync(id);
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task Add(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _repository.CreateAsync(product);
        }

        public async Task Update(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _repository.UpdateAsync(product);
        }

        public async Task Remove(int? id)
        {
            var product = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(product);
        }
    }
}