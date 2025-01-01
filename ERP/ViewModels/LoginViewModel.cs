using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonClickCommand { get; }
        private string _userName;
        private string _password;
        private string _info;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName)); // PropertyChanged tetikleniyor
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password)); // PropertyChanged tetikleniyor
                }
            }
        }

        public string Info
        {
            get => _info;
            set
            {
                if (_info != value)
                {
                    _info = value;
                    OnPropertyChanged(nameof(Info)); // PropertyChanged tetikleniyor
                }
            }
        }

        public LoginViewModel()
        {
            ButtonClickCommand = new Command(OnButtonClick); // Command'e bir metod bağlanıyor

        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnButtonClick()
        {
            if (_userName == "admin" && _password == "123456")
            {
                
                UserName = string.Empty;
                Password = string.Empty;
                Info = "";
                await Shell.Current.GoToAsync("//MainPage"); // geri dönüş olmaması için // ekledik!!!



            } 
            else
                Info = "Başarısız Giriş :(";
        }
    }


}
