using Dapper.WebUserInterface.Dtos.CategoryDtos;
using Dapper.WebUserInterface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebUserInterface.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetCategoriesAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
           await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
           var values = await _categoryService.GetCategoryByAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto  updateCategoryDto)
        {
           await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
