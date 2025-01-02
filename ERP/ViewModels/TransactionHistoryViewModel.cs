using ERP.DTOs;
using ERP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels
{
    public class TransactionHistoryViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonClickCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public IProductTransactionService productTransactionService { get; set; }
        private ObservableCollection<TransactionHistoryDTO> _transactionHistories = new ObservableCollection<TransactionHistoryDTO>();
        public ObservableCollection<TransactionHistoryDTO> TransactionHistories // view Tablosunda bind edilecek property
        {
            get => _transactionHistories;
            set
            {
                if (_transactionHistories != value)
                {
                    _transactionHistories = value;
                    OnPropertyChanged(nameof(TransactionHistories)); // Property değiştiğinde bildiriliyor
                }
            }
        }


        public TransactionHistoryViewModel(IProductTransactionService productTransactionService) 
        {
            this.productTransactionService = productTransactionService;

            Task.Run(async () => await LoadTransactionHistoriesAsync()); // ilk açılırken tabloya DB den verilerin yüklenmesi .

            ButtonClickCommand = new Command(OnButtonClick);

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadTransactionHistoriesAsync() // veritabaından çekme ve viewe gösterme
        {
            try
            {
                // Veritabanı veya dış servisten ürünleri almak
                var histories = await productTransactionService.GetProductTransactionHistory();

                TransactionHistories = new ObservableCollection<TransactionHistoryDTO>(histories); // Yeni koleksiyon oluştur ve ata
                TransactionHistories.Clear(); // Eski verileri temizle
                foreach (var product in histories)
                {
                    TransactionHistories.Add(product);
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
            await LoadTransactionHistoriesAsync();

        }

    }
}
