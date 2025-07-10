using Microsoft.EntityFrameworkCore;
using IceCreamShop.Core.Models;

namespace IceCreamShop.Data
{
    public class IceCreamShopContext : DbContext
    {
        public IceCreamShopContext(DbContextOptions<IceCreamShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<SaleItem> SaleItems { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.Name);
            });

            // Sale configuration
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.FinalAmount).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.InvoiceNumber).IsUnique();
                entity.HasIndex(e => e.SaleDate);

                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Sales)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // SaleItem configuration
            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Sale)
                    .WithMany(s => s.SaleItems)
                    .HasForeignKey(e => e.SaleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.SaleItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Customer configuration
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPurchases).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.Phone);
                entity.HasIndex(e => e.Email);
            });

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email);
            });

            // InventoryTransaction configuration
            modelBuilder.Entity<InventoryTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitCost).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalCost).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.TransactionDate);
                entity.HasIndex(e => new { e.ReferenceType, e.ReferenceId });

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.InventoryTransactions)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed default admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    FullName = "مدير النظام",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Role = "مدير",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );

            // Seed sample products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "آيس كريم فانيليا", Category = "آيس كريم", Flavor = "فانيليا", Price = 15.00m, StockQuantity = 50, MinimumStock = 10 },
                new Product { Id = 2, Name = "آيس كريم شوكولاتة", Category = "آيس كريم", Flavor = "شوكولاتة", Price = 15.00m, StockQuantity = 50, MinimumStock = 10 },
                new Product { Id = 3, Name = "آيس كريم فراولة", Category = "آيس كريم", Flavor = "فراولة", Price = 15.00m, StockQuantity = 50, MinimumStock = 10 },
                new Product { Id = 4, Name = "كوز عادي", Category = "إضافات", Flavor = "", Price = 2.00m, StockQuantity = 100, MinimumStock = 20 },
                new Product { Id = 5, Name = "كوز شوكولاتة", Category = "إضافات", Flavor = "", Price = 3.00m, StockQuantity = 100, MinimumStock = 20 }
            );
        }
    }
}
