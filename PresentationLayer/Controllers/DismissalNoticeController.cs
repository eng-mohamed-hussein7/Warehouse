using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.DismissalNoticeServices;
using BusinessLogicLayer.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class DismissalNoticeController : Controller
    {
      
        private readonly IDismissalNoticeService _dismissalNoticeService;
        private readonly IProductService _productService;

        public DismissalNoticeController(IDismissalNoticeService dismissalNoticeService, IProductService productService)
        {
            _dismissalNoticeService = dismissalNoticeService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewDismissalNotice()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Name} ({p.Code})"
            }).ToList();

            var model = new DismissalNoticeDTO
            {
                DismissalNoticeDetailDTOs = new List<DismissalNoticeDetailDTO>
                {
                    new DismissalNoticeDetailDTO()
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDismissalNotice(DismissalNoticeDTO model)
        {
            if (model == null || !ModelState.IsValid)
            {
                await _dismissalNoticeService.AddAsync(model);
                return RedirectToAction("Index", "Home");
            }

            var products = await _productService.GetAllProductsAsync();
            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Name} ({p.Code})"
            }).ToList();
            return RedirectToAction("CreateNewPurchaseInvoice");
        }
    }
}
