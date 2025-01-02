
using System;

namespace ProductCodeGenerator
{
    public class ProductCodeGeneratorService
    {
        public string GenerateProductCode(string categoryName, string productName)
        {
            // Kategori adının ilk iki harfini ve bir sayı ekleyerek ProductCode oluştur
            string productCode = categoryName.Substring(0, 2).ToUpper() + "-" + new Random().Next(1, 1000).ToString("D3");
            return productCode;
        }
    }
}
