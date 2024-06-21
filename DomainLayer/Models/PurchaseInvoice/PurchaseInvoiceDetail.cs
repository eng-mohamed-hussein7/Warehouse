using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.PurchaseInvoice
{
    public class PurchaseInvoiceDetail:GeneralEntity
    {
        public int ResivedQuantity { get; set; }
        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("PurchaseInvoiceHead")]
        public int PurchaseInvoiceHead_ID { get; set; }
        public virtual PurchaseInvoiceHead PurchaseInvoiceHead { get; set; }
    }
}