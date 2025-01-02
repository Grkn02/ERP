using ERP.DTOs;
using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public class ProductTransactionService : IProductTransactionService
    {
        private readonly AppDbContext _context;

        public ProductTransactionService(AppDbContext context)
        {
            _context = context;
     
        }

        public async Task AddProductTransactionAsync(ProductTransaction productTransaction)
        {
           _context.ProductTransactions.Add(productTransaction);
           _context.SaveChanges();
        }

        public async Task<List<TransactionHistoryDTO>> GetProductTransactionHistory()
        {
            var transactionHistories = _context.ProductTransactions
                .Include(pt => pt.Product)
                .Select(pt => new TransactionHistoryDTO
                {
                    TransactionDate = pt.TransactionDate,
                    TransactionType = pt.TransactionType,
                    Category = pt.Product.Category,
                    ProductCode = pt.Product.ProductCode,
                    Name = pt.Product.Name,
                    Quantity = pt.Quantity,
                    TransactionPrice = pt.TransactionPrice,
                    PartyName = pt.PartyName,
                    Description = pt.Description
                    
                }).ToList();

            return transactionHistories;

        }




    }
}
