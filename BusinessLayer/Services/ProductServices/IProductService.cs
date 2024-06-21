using BusinessLogicLayer.DTO;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<ProductDTOForViewInTable>> GetAllProductsForViewAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductDTO product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
