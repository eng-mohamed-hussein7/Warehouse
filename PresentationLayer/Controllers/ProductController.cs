using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.CategoryServices;
using BusinessLogicLayer.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using static DomainLayer.Enums.Enums;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CreateNewProduct()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            var model = new ProductDTO
            {
                Categories = categories.Select(c => new CustomSelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList(),
                UnitTypes = Enum.GetValues(typeof(UnitType)).Cast<UnitType>().Select(ut => new CustomSelectListItem
                {
                    Value = ((int)ut).ToString(),
                    Text = ut.ToString()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(ProductDTO product)
        {
            if (product == null || !ModelState.IsValid)
            {
                // Re-populate the dropdown lists before returning the view
                product.Categories = (await _categoryService.GetAllCategoriesAsync()).Select(c => new CustomSelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                product.UnitTypes = Enum.GetValues(typeof(UnitType)).Cast<UnitType>().Select(ut => new CustomSelectListItem
                {
                    Value = ((int)ut).ToString(),
                    Text = ut.ToString()
                }).ToList();

                return View(product);
            }

            await _productService.AddProductAsync(product);
            return RedirectToAction("Index", "Home");
        }
    }
}
