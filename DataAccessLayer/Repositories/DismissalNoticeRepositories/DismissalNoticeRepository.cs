using DataAccessLayer.Data;
using DomainLayer.Models.DismissalNotice;

namespace DataAccessLayer.Repositories.DismissalNoticeRepositories
{
    public class DismissalNoticeRepository : IDismissalNoticeRepository
    {
        private readonly ApplicationDbContext _context;

        public DismissalNoticeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DismissalNoticeHeader dismissalNoticeHeader, List<DismissalNoticeDetail> dismissalNoticeDetails)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.tblDismissalNoticeHeader.AddAsync(dismissalNoticeHeader);
                await _context.SaveChangesAsync();

                foreach (var item in dismissalNoticeDetails)
                {
                    var product = await _context.tblProducts.FindAsync(item.Product_ID);
                    if (product != null)
                    {
                        product.Quantity += item.Quantity;

                        _context.tblProducts.Update(product);
                    }

                    item.DismissalNoticeHeader_ID = dismissalNoticeHeader.Id;

                    await _context.tblDismissalNoticeHeader.AddAsync(dismissalNoticeHeader);
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DismissalNoticeHeader>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DismissalNoticeHeader> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DismissalNoticeHeader invoiceHead)
        {
            throw new NotImplementedException();
        }
    }
}
