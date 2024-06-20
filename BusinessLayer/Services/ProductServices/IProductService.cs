using BusinessLogicLayer.DTO;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product, int categoryID);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
