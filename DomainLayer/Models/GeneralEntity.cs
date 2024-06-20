namespace DomainLayer.Models
{
    public class GeneralEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateOfAddition { get; set; }
        public DateTime DateOfDeletion { get; set; }

    }
}
