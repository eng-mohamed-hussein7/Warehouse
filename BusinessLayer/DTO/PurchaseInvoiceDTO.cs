using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public class PurchaseInvoiceDTO
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public List<PurchaseInvoiceDetailDTO> PurchaseInvoiceDetails { get; set; }
    }
}

public class PurchaseInvoiceDetailDTO
{
    public int Id { get; set; }
    public int ResivedQuantity { get; set; }
    public int Product_ID { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public int PurchaseInvoiceHead_ID { get; set; }
}
