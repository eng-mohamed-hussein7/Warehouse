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

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
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
