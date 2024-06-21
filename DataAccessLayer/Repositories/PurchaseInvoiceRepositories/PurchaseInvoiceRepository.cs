using DataAccessLayer.Data;
using DomainLayer.Models.PurchaseInvoice;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.PurchaseInvoiceRepositories
{
    public class PurchaseInvoiceRepository : IPurchaseInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseInvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseInvoiceHead>> GetAllAsync()
        {
            return await _context.tblPurchaseInvoiceHeads
                                 .Include(p => p.PurchaseInvoiceDetails)
                                 .ThenInclude(d => d.Product)
                                 .ToListAsync();
        }

        public async Task<PurchaseInvoiceHead> GetByIdAsync(int id)
        {
            return await _context.tblPurchaseInvoiceHeads
                                 .Include(p => p.PurchaseInvoiceDetails)
                                 .ThenInclude(d => d.Product)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(PurchaseInvoiceHead invoiceHead, List<PurchaseInvoiceDetail> purchaseInvoiceDetails)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.tblPurchaseInvoiceHeads.AddAsync(invoiceHead);
                await _context.SaveChangesAsync();

                foreach (var item in purchaseInvoiceDetails)
                {
                    var product = await _context.tblProducts.FindAsync(item.Product_ID);
                    if (product != null)
                    {
                        product.Quantity += item.ResivedQuantity;

                        _context.tblProducts.Update(product);
                    }

                    item.PurchaseInvoiceHead_ID = invoiceHead.Id;

                    await _context.tblPurchaseInvoiceDetails.AddAsync(item);
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

        public async Task UpdateAsync(PurchaseInvoiceHead invoiceHead)
        {
            _context.tblPurchaseInvoiceHeads.Update(invoiceHead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var invoiceHead = await GetByIdAsync(id);
            if (invoiceHead != null)
            {
                _context.tblPurchaseInvoiceHeads.Remove(invoiceHead);
                await _context.SaveChangesAsync();
            }
        }
    }
}
