using Warehouse.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BrancOps.Api.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<StockTransfer> StockTransfers => Set<StockTransfer>();
    public DbSet<TransferEvent> TransferEvents => Set<TransferEvent>();

    protected override void OnModelCreating((ModelBuilder modelBuilder)
    {
        // One inventory row per product per branch
        modelBUilder.Entity<InventoryItem>()
            .HasIndex(item => new
            {
                item.BranchId,
                item.ProductId
            })
            .IsUnique();

        //SKUs must identify unique products
        modelBUilder.Entity.Entity<Product>()
            .HasIndex(product => product.Sku)
            .IsUnique();
        
        // Limit transfer status string length
        modelBuilder.Entity<StockTransfer>()
            .Property(transfer => transfer.Status)
            .HasMaxLength(20);
    }
}