using DataAccessLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.CategoryService
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
           
            await _context.tblCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.tblCategories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.tblCategories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
