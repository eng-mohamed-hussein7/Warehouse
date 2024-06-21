namespace DomainLayer.Models.PurchaseInvoice
{
    public class PurchaseInvoiceHead : GeneralEntity
    {
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public virtual List<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

    }
}