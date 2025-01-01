using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DTOs
{
    public class TransactionHistoryDTO // işlem geçmişi biligilerini tutabilen veritaabnı sorgu sonucu oalrak ve viewmodelda uygun observablecollection tür tanımlaması için DTO tanımladık.Veritabanını modelize etmez!
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string Category { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal TransactionPrice { get; set; }
        public string PartyName { get; set; }
        public string Description { get; set; }


    }
}
