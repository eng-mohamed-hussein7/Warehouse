using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.DismissalNotice
{
    public class DismissalNoticeDetail:GeneralEntity
    {
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public string Notes { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("DismissalNoticeHeader")]
        public int DismissalNoticeHeader_ID { get; set; }
        public virtual DismissalNoticeHeader DismissalNoticeHeader { get; set; }
    }
}
