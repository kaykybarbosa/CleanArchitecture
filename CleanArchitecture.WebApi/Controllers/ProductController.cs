using Azure.Core;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hosting;

        public ProductController(IProductService service, ICategoryService categoryService, IWebHostEnvironment hosting)
        {
            _service = service;
            _categoryService = categoryService;
            _hosting = hosting;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Add(request);
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var productVM = await _service.GetById(id);
            if (productVM == null)
                return NotFound();

            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productVM.CategoryId);


            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO request)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var productVM = await _service.GetById(id);
            if (productVM == null)
                return NotFound();

            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productVM.CategoryId);

            return View(productVM);
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
            if (id == null)
                return NotFound();

            var productVM = await _service.GetById(id);
            if (productVM == null)
                return NotFound();

            if (productVM.Image == null)
            {
                ViewBag.ExistImage = false;
            }
            ViewBag.ExistImage = true;

            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productVM.CategoryId);

            return View(productVM);
        }
    }
}