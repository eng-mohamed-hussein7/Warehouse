using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.CategoryServices;
using DataAccessLayer.Repositories.ProductRepositories;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;

        public ProductService(IProductRepository productRepository, ICategoryService categoryService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        { 
            return await _productRepository.GetAllAsync();
        }
            public async Task<IEnumerable<ProductDTOForViewInTable>> GetAllProductsForViewAsync()
        {
            var products = await _productRepository.GetAllAsync();
            List<ProductDTOForViewInTable> ListOfProducts = new List<ProductDTOForViewInTable>();
            foreach (var product in products)
            {
                var categoryName = await _categoryService.GetCategoryNameByIdAsync(product.Category_Id);

                ProductDTOForViewInTable productDTO = new ProductDTOForViewInTable()
                {
                    Code = product.Code,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    UnitType = product.UnitType.ToString(),
                    CategoryName = categoryName
                };
                ListOfProducts.Add(productDTO);
            }
            return ListOfProducts;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
                
        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task AddProductAsync(ProductDTO product)
        {
            Product newProduct = new Product()
            {
                Code = product.Code,
                Name = product.Name,
                DateOfAddition = DateTime.Now,
                Description = product.Description,
                UnitType = product.UnitType,
                Price = product.Price,
                Quantity = product.Quantity,
                Category_Id = product.CategoryId,
                IsDeleted = false,
            };
            await _productRepository.AddAsync(newProduct);
        }
    }
    }
