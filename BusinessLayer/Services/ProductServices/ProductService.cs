using BusinessLogicLayer.DTO;
using DataAccessLayer.Repositories.ProductRepositories;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        //public async Task AddProductAsync(ProductDTO product,int categoryID)
        //{
        //    Product newProduct = new Product()
        //    {
        //        Code = product.Code,
        //        Name = product.Name,
        //        DateOfAddition = DateTime.Now,
        //        Description = product.Description,
        //        UnitType = product.UnitType,
        //        Price = product.Price,
        //        Quantity = product.Quantity,
        //        Category_Id = categoryID,
        //        IsDeleted = false,
        //    };
        //    await _productRepository.AddAsync(newProduct);
        //}

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public Task AddProductAsync(Product product, int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
