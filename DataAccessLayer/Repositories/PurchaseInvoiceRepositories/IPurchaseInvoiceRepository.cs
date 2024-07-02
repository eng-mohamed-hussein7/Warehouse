using DomainLayer.Models.PurchaseInvoice;

namespace DataAccessLayer.Repositories.PurchaseInvoiceRepositories
{
    public interface IPurchaseInvoiceRepository
    {
        Task<IEnumerable<PurchaseInvoiceHead>> GetAllAsync();
        Task<PurchaseInvoiceHead> GetByIdAsync(int id);
        Task AddAsync(PurchaseInvoiceHead invoiceHead,List<PurchaseInvoiceDetail> purchaseInvoiceDetails);
        Task UpdateAsync(PurchaseInvoiceHead invoiceHead);
        Task DeleteAsync(int id);
    }
}
