using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services 
{

    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can customize the model further here if needed
            
            

        }
        public static void Initialize(AppDbContext context) // Test veritabanı başlangıç verilerini eklemek için
        {
            // Veritabanı var mı kontrol et
            if (!context.Products.Any())
            {
                // Eğer veritabanında veri yoksa, test verilerini ekle
                context.Products.AddRange(
                    new Product { Id = 1, ProductCode = "P001", Name = "Product 1", Category = "Yiyecek", Cost = 5, Price = 10, CurrentStock = 100, LastUpdated = DateTime.Now },
                    new Product { Id = 2, ProductCode = "P002", Name = "Product 2", Category = "Yiyecek", Cost = 5, Price = 12, CurrentStock = 200, LastUpdated = DateTime.Now },
                    new Product { Id = 3, ProductCode = "P003", Name = "Product 3", Category = "İçecek", Cost = 8, Price = 15, CurrentStock = 150, LastUpdated = DateTime.Now },
                    new Product { Id = 4, ProductCode = "P004", Name = "Product 4", Category = "Temizlik", Cost = 10, Price = 20, CurrentStock = 80, LastUpdated = DateTime.Now },
                    new Product { Id = 5, ProductCode = "P005", Name = "Product 5", Category = "Elektronik", Cost = 50, Price = 100, CurrentStock = 30, LastUpdated = DateTime.Now },
                    new Product { Id = 6, ProductCode = "P006", Name = "Product 6", Category = "Mobilya", Cost = 120, Price = 250, CurrentStock = 10, LastUpdated = DateTime.Now },
                    new Product { Id = 7, ProductCode = "P007", Name = "Product 7", Category = "Oyuncak", Cost = 15, Price = 30, CurrentStock = 50, LastUpdated = DateTime.Now },
                    new Product { Id = 8, ProductCode = "P008", Name = "Product 8", Category = "Kırtasiye", Cost = 3, Price = 8, CurrentStock = 500, LastUpdated = DateTime.Now },
                    new Product { Id = 9, ProductCode = "P009", Name = "Product 9", Category = "Kozmetik", Cost = 25, Price = 60, CurrentStock = 70, LastUpdated = DateTime.Now },
                    new Product { Id = 10, ProductCode = "P010", Name = "Product 10", Category = "Bahçe", Cost = 40, Price = 90, CurrentStock = 25, LastUpdated = DateTime.Now },
                    new Product { Id = 11, ProductCode = "P011", Name = "Product 11", Category = "Giyim", Cost = 20, Price = 45, CurrentStock = 200, LastUpdated = DateTime.Now },
                    new Product { Id = 12, ProductCode = "P012", Name = "Product 12", Category = "Yiyecek", Cost = 7, Price = 14, CurrentStock = 300, LastUpdated = DateTime.Now }
                );
                context.ProductTransactions.AddRange(
                    new ProductTransaction { ProductId = 1, TransactionType = "Exit", Quantity = 50, TransactionPrice = 10, PartyName = "Supplier A", TransactionDate = DateTime.Now.AddDays(-10), Description = "Initial stock purchase" },
                    new ProductTransaction { ProductId = 2, TransactionType = "Entry", Quantity = 30, TransactionPrice = 12, PartyName = "Customer B", TransactionDate = DateTime.Now.AddDays(-5), Description = "Sale to customer" },
                    new ProductTransaction { ProductId = 1, TransactionType = "Exit", Quantity = 20, TransactionPrice = 10, PartyName = "Customer C", TransactionDate = DateTime.Now.AddDays(-3), Description = "Sold some units" },
                    new ProductTransaction { ProductId = 2, TransactionType = "Entry", Quantity = 100, TransactionPrice = 12, PartyName = "Supplier B", TransactionDate = DateTime.Now.AddDays(-1), Description = "Re-stock after sales" }
                );
                context.Users.AddRange(
                    new User { Id = 1, Username = "admin", PasswordHash = "vFLgZTeANpEiamS1OZIdwyb5lim2qfUZ6ey+b1b6xtQ=:SuWyHKqaFrKNudLvQBzK9e3w2JzEXcM/Oryj6Jg5WPc=", Name = "Babişko", Surname = "Asuman", Email = "babisko@gmail.com", CreatedAt = DateTime.Now.AddDays(-10) }   
                );

                // şifre = 123456 için hashlenmiş hali =  "vFLgZTeANpEiamS1OZIdwyb5lim2qfUZ6ey+b1b6xtQ=:SuWyHKqaFrKNudLvQBzK9e3w2JzEXcM/Oryj6Jg5WPc="
                // Veritabanına değişiklikleri kaydet
                context.SaveChanges();
            }
        }



    }
}
