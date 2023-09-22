using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetCategories();
            return View(categories);
        }
    }
}
