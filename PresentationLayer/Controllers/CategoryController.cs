using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CreateNewCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CategoryDTO category)
        {
            if (category == null || !ModelState.IsValid)
            {
                return View("CreateNewCategory", category);
            }

            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index", "Home");
        }

       
    }
}
