using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services.DismissalNoticeServices
{
    public interface IDismissalNoticeService
    {
        Task<IEnumerable<DismissalNoticeDTO>> GetAllAsync();
        Task<DismissalNoticeDTO> GetByIdAsync(int id);
        Task AddAsync(DismissalNoticeDTO invoiceDto);
        Task UpdateAsync(DismissalNoticeDTO invoiceDto);
        Task DeleteAsync(int id);
    }
}
