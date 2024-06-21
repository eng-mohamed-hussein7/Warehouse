using System.ComponentModel.DataAnnotations;
using static DomainLayer.Enums.Enums;

namespace BusinessLogicLayer.DTO
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public UnitType UnitType { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CustomSelectListItem> Categories { get; set; } = new List<CustomSelectListItem>();

        public List<CustomSelectListItem> UnitTypes { get; set; } = new List<CustomSelectListItem>();
    }
    public class ProductDTOForViewInTable
    {
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string UnitType { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

    }
   
}
