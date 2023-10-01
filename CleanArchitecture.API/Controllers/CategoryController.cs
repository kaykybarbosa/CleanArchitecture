using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var category = await _service.GetCategories();
            if (category != null)
                return Ok(category);

            return NotFound("Categories are empty!");
        }

        [HttpGet("category/{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _service.GetById(id);
            if (category != null)
                return Ok(category);

            return NotFound("Category by id not found!");
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDto)
        {
            await _service.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new CategoryDTO { Id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id == categoryDTO.Id)
            {
                var category = await _service.GetById(id);
                if (category != null)
                {
                    await _service.Update(categoryDTO);
                    var categoryUpdated = await _service.GetById(categoryDTO.Id);
                    
                    return Ok(categoryUpdated);
                }

                return NotFound("Category not found!");
            }

            return BadRequest("'Id' don´t match!");
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _service.GetById(id);
            if (category != null)
            {
                await _service.Remove(id);

                return Ok(category);
            }

            return NotFound("Category by id not found!");
        }
    }
}
