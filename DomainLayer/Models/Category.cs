using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Category : GeneralEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
