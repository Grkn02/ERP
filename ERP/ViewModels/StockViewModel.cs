using ERP.Models;
using ERP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ERP.ViewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        private string _productCode;
        private string _name;
        private string _category;
        private int _quantity;
        private decimal _price;
        private string _customer;
        private string _description;

        //ilgili viewin entry kısmındaki bind edilecek propertyler
        public string ProductCodef
        {
            get => _productCode;
            set => SetProperty(ref _productCode, value); // SetProperty metodu ile property değiştiğinde bildirim yapılır.onpropertychanged metodu otomatik çağrılır.
        }
        public string Namef
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Categoryf
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }
        public int Quantityf
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }
        public decimal Pricef
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
        public string Customerf
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        public string Descriptionf
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ButtonClickCommand { get; }

        public IProductTransactionService ProductTransactionservice { get; set; }
        public IProductService Productservice { get; set; } 
        private ObservableCollection<Product> _products =  new ObservableCollection<Product>();
        public ObservableCollection<Product> Products // view Tablosunda bind edilecek property
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products)); // Property değiştiğinde bildiriliyor
                }
            }
        }

       
        public StockViewModel(IProductService Productservice, IProductTransactionService ProductTransactionservice) // DI kullanımı
        {
            this.Productservice = Productservice;
            this.ProductTransactionservice = ProductTransactionservice;
          
            Task.Run(async () => await LoadProductsAsync()); // ilk açılırken tabloya DB den verilerin yüklenmesi .

            ButtonClickCommand = new Command(OnButtonClick);

        }

   

        public async Task LoadProductsAsync() // veritabaından çekme ve viewe gösterme
        {
            try
            {
                // Veritabanı veya dış servisten ürünleri almak
                var products = await Productservice.GetAllProductsAsync();
                
                Products = new ObservableCollection<Product>(products); // Yeni koleksiyon oluştur ve ata
                Products.Clear(); // Eski verileri temizle
                foreach (var product in products)
                {
                    Products.Add(product);
                }

            }
            catch (Exception ex)
            {
                // Hata işleme
                Debug.WriteLine($"Error fetching products: {ex.Message}");
            }
        }

        private async void OnButtonClick()
        {

            await AddProductValuesAsync();
            await AddTransactionValuesAsync();
            await LoadProductsAsync();




        }

        public async Task AddTransactionValuesAsync() // kullanıcı girdiği entryler DB ye işleme amaçlı çalışan method
        {
            var product =  await Productservice.GetProductByProductCodeAsync(ProductCodef);

            if (product == null)
            {
                // Ürün bulunamadıysa bir hata fırlatabilirsiniz ya da uygun bir işlem yapabilirsiniz.
                throw new Exception("Product not found.");
            }
            else
            {
                var productTransaction = new ProductTransaction()
                {
                    ProductId = product.Id, // foreign key değer ataması şart
                    TransactionType = "Exit",
                    Quantity = Quantityf,
                    TransactionPrice = Pricef,
                    PartyName = Customerf,
                    Description = Descriptionf  
                };

               await ProductTransactionservice.AddProductTransactionAsync(productTransaction); // yapılan işlemin transaction bilgileri DB ye kaydederiz

            }


        }

        public async Task AddProductValuesAsync()// kullanıcı girdiği entryler DB ye işleme amaçlı çalışan method
        {
            var product = await Productservice.GetProductByProductCodeAsync(ProductCodef);

            if (product == null)
            {
                // Ürün bulunamadıysa bir hata fırlattık.
                throw new Exception("Product not found.");
            }
            else
            {
                
                await Productservice.UpdateProductAsync(product.Id,Quantityf,Pricef,false);   // falsw atması yaptık çünkü cost değeri güncelliyoruz
               

            }



        }
        


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null) 
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }



    }
}
