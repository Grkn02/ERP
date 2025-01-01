using ERP.Models;

namespace ERP.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByProductCodeAsync(string productCode);
        //Task AddProductAsync(Product product);
        public Task UpdateProductAsync(int Id, int stockChange, decimal costOrPrice, bool iscost);
        //Task DeleteProductAsync(int id);
       
    }
}
