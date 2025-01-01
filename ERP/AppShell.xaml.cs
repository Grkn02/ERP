using ERP.Views;

namespace ERP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Route tanımlamaları hem xaml hem .cs içinde yap!!!
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("StockPage", typeof(StockPage));
            Routing.RegisterRoute("StockEntryPage", typeof(StockEntryPage));
            Routing.RegisterRoute("TransactionHistoryPage", typeof(TransactionHistoryPage));
          

           
        }

        
    
    }
}
