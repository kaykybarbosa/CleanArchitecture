using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Application.Products.Queries;
using MediatR;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var productQuery = new GetProductsQuery();

            if (productQuery == null)
                throw new ApplicationException("Entity could not be loaded.");

            var products = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new ApplicationException("Entity could not be loaded.");

            var product = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO request)
        {
            var productCommand = _mapper.Map<ProductCreateCommand>(request);

            await _mediator.Send(productCommand);

        }

        public async Task Update(ProductDTO request)
        {
            var productCommand = _mapper.Map<ProductUpdateCommand>(request);

            await _mediator.Send(productCommand);
        }

        public async Task Remove(int? id)
        {
            var productCommand = new ProductRemoveCommand(id.Value);
            if (productCommand == null)
                throw new ApplicationException("Entity could not be loaded.");

            await _mediator.Send(productCommand);
        }
    }
}