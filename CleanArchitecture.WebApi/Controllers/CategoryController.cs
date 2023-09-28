using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infra.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO request)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(request);
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var categoryVM = await _service.GetById(id);
            if (categoryVM == null)
                return NotFound();

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(request);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var categoryVM = await _service.GetById(id);
            if (categoryVM == null)
                return NotFound();

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();

            var categoryVM = await _service.GetById(id);
            if(categoryVM == null)
                return NotFound();

            return View(categoryVM);    
        }
    }
}