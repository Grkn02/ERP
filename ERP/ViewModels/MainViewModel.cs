
using ERP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels 
{
    internal class MainViewModel 
    {
        public ICommand ButtonClickCommand { get; }
        
        public MainViewModel() 
        {
            ButtonClickCommand = new Command<string>(OnButtonClick);

        }

        private async void OnButtonClick(string buttonMenu )
        {
            if (buttonMenu == nameof(LoginPage))  await Shell.Current.GoToAsync("//"+buttonMenu) ; // çıkış yapırken menüye geri dönüş yapılmasın die ekledik
            else await Shell.Current.GoToAsync(buttonMenu);
        }

    }
}
