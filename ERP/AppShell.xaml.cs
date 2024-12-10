using ERP.Views;

namespace ERP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Route tanımlamaları
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
        }
    }
}
