using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("Products")] // EF tarafından tabloya dönüştürülürken tablo adı "TransactionHistories" olur ya da DBContext içinde modelbuilder kullnarak model adı tanımalsı yapmalsınız!
    public class Product
    {
        [Key] // Birincil anahtar ve default olarak auto-increment!
        public int Id { get; set; }

        [Required] // Boş olamaz
        [MaxLength(100)] // Maksimum uzunluk
        public string ProductCode { get; set; } // Ürün kodu (örneğin: SKU)

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } // Ürün adı

        [MaxLength(100)]
        public string Category { get; set; } // Kategori (örneğin: Elektronik)

        [Required]
        public int CurrentStock { get; set; } // Mevcut stok miktarı (şimdilik adet cinsinden)

        [Column(TypeName = "decimal(18,2)")] // Hassasiyet ayarı
        public decimal? Cost { get; set; } //   Birim maliyet (nullable)

        [Column(TypeName = "decimal(18,2)")] // Hassasiyet ayarı
        public decimal? Price { get; set; } //  Birim fiyat (nullable)

        public DateTime LastUpdated { get; set; } = DateTime.Now; // Son güncelleme tarihi (varsayılan: şimdi)

    }
}
