using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTO
{
    public class CategoryDTO
    {

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
