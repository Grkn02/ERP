
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
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context) //DI kullnarak new anahtar kelimesi ile instance oluşturmamız gerekmedi manuel olarak. Parametre oalrak aldık DI sayesinde.
        {
            _context = context;
        }

        //Tüm ürünleri getirme
        public async Task<List<Product>> GetAllProductsAsync()
        {
            // var count = await _context.TransactionHistories.CountAsync(); break point ekleyip değer tutup tutmadığını test etmek için

            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByProductCodeAsync(string productCode)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == productCode); // bulunamazsa  null değer döner
        }

        public async Task UpdateProductAsync(int Id, int stockChange, decimal costOrPrice, bool iscost ) // iscost true ise ürün alınmış değilse satılmış
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            if (iscost) // ürün alınıyorsa depoya ortalama birim maaliyet hesabı yapılıp atanıcak DB ye (divided by zero ve null exceptionları ayarla sonra)
            {
                decimal result = Math.Round(((product.CurrentStock * product.Cost.Value) + (stockChange * costOrPrice)) / (product.CurrentStock + stockChange), 2);
                product.Cost = result;

                product.CurrentStock += stockChange;
            }
            else
            {
                product.Price = costOrPrice; // depodan ürün satılıyorsa

                product.CurrentStock -= stockChange;
            }
            product.LastUpdated = DateTime.Now;
            
            _context.SaveChanges();
          
        }

        public async Task AddProductAsync(Product newproduct)
        {


        } 

        //// Ürün ID ile getirme
        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    return await _context.TransactionHistories.FirstOrDefaultAsync(p => p.Id == id);
        //}
    }
}
