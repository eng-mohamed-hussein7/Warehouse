using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DomainLayer.Enums.Enums;

namespace DomainLayer.Models
{
    public class Product: GeneralEntity
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

        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }
       
    }
}
