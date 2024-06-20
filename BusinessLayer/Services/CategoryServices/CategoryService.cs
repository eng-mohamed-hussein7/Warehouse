using BusinessLogicLayer.DTO;
using DataAccessLayer.Repositories.CategoryService;
using DomainLayer.Models;

namespace BusinessLogicLayer.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) 
        { 
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategoryAsync(CategoryDTO category)
        {
            Category newCategory = new Category()
            {
                DateOfAddition = DateTime.Now,
                Name = category.Name,
                Description = category.Description,
                IsDeleted = false,

            };
            await _categoryRepository.AddAsync(newCategory);
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
           
                var categories = await _categoryRepository.GetAllAsync();
                return categories.Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToList();
            
        }

        public Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
