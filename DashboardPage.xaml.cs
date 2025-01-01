namespace Proje2;
using CommunityToolkit.Maui.Animations;
using System.Collections.ObjectModel;

public partial class DashboardPage : ContentPage
{
    public ObservableCollection<Sale> Sales { get; set; }

    public DashboardPage()
    {
        InitializeComponent();
        Sales = new ObservableCollection<Sale>
        {
            new Sale { ProductId = 1, ProductName = "Ürün A", SalePrice = 100 },
            new Sale { ProductId = 2, ProductName = "Ürün B", SalePrice = 150 },
            // Diðer satýþlarý buraya ekleyebilirsiniz
        };
        SalesListView.ItemsSource = Sales;
    }

    private async void OnDepoClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        await button.ScaleTo(2.0, 100); // Butonu büyüt
        await button.ScaleTo(1.0, 100); // Butonu eski boyutuna döndür
        await Navigation.PushAsync(new FinancePage()); // Depo sayfasýna yönlendirme
    }

    private async void OnFinanceClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        await button.ScaleTo(2.0, 100); // Butonu büyüt
        await button.ScaleTo(1.0, 100); // Butonu eski boyutuna döndür                             
        await Navigation.PushAsync(new FinancePage()); // Finans sayfasýna yönlendirme
    }

    private async void OnCreateReminderClicked(object sender, EventArgs e)
    {
        var selectedDate = ReminderDate.Date; // Hatýrlatýcý tarihini al
        // Hatýrlatýcý ayarlama iþlemleri burada yapýlabilir
        await DisplayAlert("Hatýrlatýcý", $"Hatýrlatýcý {selectedDate} için oluþturuldu.", "Tamam");
    }
}

// Satýþ bilgilerini temsil eden sýnýf
public class Sale
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal SalePrice { get; set; }
}
