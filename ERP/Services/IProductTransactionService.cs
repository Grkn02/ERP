using ERP.DTOs;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public interface IProductTransactionService
    {
        public Task AddProductTransactionAsync(ProductTransaction productTransaction);
        public Task<List<TransactionHistoryDTO>> GetProductTransactionHistory(); // işlem geçmişi bilgilerini çekmek için
    }
}
