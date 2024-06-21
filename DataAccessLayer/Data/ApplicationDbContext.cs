using DomainLayer.Models;
using DomainLayer.Models.PurchaseInvoice;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> tblProducts { get; set; }
        public DbSet<Category> tblCategories { get; set; }
        public DbSet<PurchaseInvoiceHead> tblPurchaseInvoiceHeads { get; set; }
        public DbSet<PurchaseInvoiceDetail> tblPurchaseInvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseInvoiceHead>()
                .HasMany(p => p.PurchaseInvoiceDetails)
                .WithOne(d => d.PurchaseInvoiceHead)
                .HasForeignKey(d => d.PurchaseInvoiceHead_ID);

            modelBuilder.Entity<PurchaseInvoiceDetail>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.Product_ID);
        }
    }
}
