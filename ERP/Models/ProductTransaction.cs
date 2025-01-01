using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("ProductTransactions")] // EF tarafından tabloya dönüştürülürken tablo adı "ProductsTransactions" olur
    public class ProductTransaction
    {
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("Product")]
        public int ProductId { get; set; } // İşlem yapılan ürün

        public virtual Product Product { get; set; } // Navigation property to the related Product

        [Required]
        public string TransactionType { get; set; } // Type of transaction (e.g., "Purchase", "Sale")

        [Required]
        public int Quantity { get; set; } // İşlem edilen miktar 

        [Column(TypeName = "decimal(18,2)")]
        public decimal TransactionPrice { get; set; } // Birim fiyat alınan ya da satılan

        public string PartyName { get; set; }  // The person or company involved in the transaction (e.g., seller or buyer)

        public DateTime TransactionDate { get; set; } = DateTime.Now; // İşlem tarihi

        [MaxLength(500)]
        public string? Description { get; set; } // Açıklama opsiyonel


    }
}
