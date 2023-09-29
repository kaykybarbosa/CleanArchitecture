using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var category = await _service.GetCategories();
            if (category != null)
                return Ok(category);

            return NotFound("Categories not found!");
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _service.GetById(id);
            if (category != null)
                return Ok(category);

            return NotFound("Category by id not found!");
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto != null)
            {
                await _service.Add(categoryDto);

                return new CreatedAtRouteResult("GetCategory", new CategoryDTO { Id = categoryDto.Id }, categoryDto);
            }

            return BadRequest("Invalid data!");
        }
    }
}
