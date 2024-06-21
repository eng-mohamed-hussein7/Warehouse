using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services.PurchaseInvoiceServices
{
    public interface IPurchaseInvoiceService
    {
        Task<IEnumerable<PurchaseInvoiceDTO>> GetAllAsync();
        Task<PurchaseInvoiceDTO> GetByIdAsync(int id);
        Task AddAsync(PurchaseInvoiceDTO invoiceDto);
        Task UpdateAsync(PurchaseInvoiceDTO invoiceDto);
        Task DeleteAsync(int id);
    }
}
