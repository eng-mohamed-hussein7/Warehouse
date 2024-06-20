using DataAccessLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.tblProducts.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.tblProducts.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.tblProducts.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.tblProducts.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.tblProducts.FindAsync(id);
            if (product != null)
            {
                _context.tblProducts.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
