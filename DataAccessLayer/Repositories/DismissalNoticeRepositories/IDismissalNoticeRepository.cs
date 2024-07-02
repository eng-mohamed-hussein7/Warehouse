using DomainLayer.Models.DismissalNotice;

namespace DataAccessLayer.Repositories.DismissalNoticeRepositories
{
    public interface IDismissalNoticeRepository
    {
        Task<IEnumerable<DismissalNoticeHeader>> GetAllAsync();
        Task<DismissalNoticeHeader> GetByIdAsync(int id);
        Task AddAsync(DismissalNoticeHeader dismissalNoticeHeader, List<DismissalNoticeDetail> dismissalNoticeDetails);
        Task UpdateAsync(DismissalNoticeHeader invoiceHead);
        Task DeleteAsync(int id);
    }
}
