using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.ProductServices;
using BusinessLogicLayer.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Services.PurchaseInvoiceServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class PurchaseInvoiceController : Controller
    {
        private readonly IPurchaseInvoiceService _purchaseInvoiceService;
        private readonly IProductService _productService;

        public PurchaseInvoiceController(IPurchaseInvoiceService purchaseInvoiceService, IProductService productService)
        {
            _purchaseInvoiceService = purchaseInvoiceService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewPurchaseInvoice()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Name} ({p.Code})"
            }).ToList();

            var model = new PurchaseInvoiceDTO
            {
                PurchaseInvoiceDetails = new List<PurchaseInvoiceDetailDTO>
                {
                    new PurchaseInvoiceDetailDTO()
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPurchaseInvoice(PurchaseInvoiceDTO model)
        {
            if (model==null|| !ModelState.IsValid)
            {
                await _purchaseInvoiceService.AddAsync(model);
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
