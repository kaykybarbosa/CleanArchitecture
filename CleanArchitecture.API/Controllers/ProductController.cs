using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts() 
        {
            var products = await _service.GetAll();
            if (products != null)
                return Ok(products);

            return NotFound("Products are empty!");
        }

        [HttpGet("product/{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _service.GetById(id);
            if (product != null)
                return Ok(product);

            return NotFound("Product not found!");
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] ProductDTO productDto) 
        {
            await _service.Add(productDto);
            
            return new CreatedAtRouteResult("GetProduct", new ProductDTO { Id = productDto.Id}, productDto);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO productDto)
        {
            if (id == productDto.Id)
            {
                var product = await _service.GetById(id);
                if (product != null)
                {
                    await _service.Update(productDto);
                    var productUpdated = await _service.GetById(id);

                    return Ok(productUpdated);
                }

                return NotFound("Product not found!");
            }

            return BadRequest("'Id' don´t match!");
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _service.GetById(id);
            if (product != null)
            {
                await _service.Remove(id);

                return Ok(product);
            }

            return NotFound("Product not found!");
        }
    }
}
