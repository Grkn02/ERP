using ERP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public IUserService Userservice { get; set; }
        public ICommand ButtonClickCommand { get; }
        public ICommand RouteRegisterCommand { get; }
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

        public RegisterViewModel(IUserService Userservice)
        {
            this.Userservice = Userservice;
            ButtonClickCommand = new Command(OnButtonClick); // Command'e bir metod bağlanıyor
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnButtonClick()
        {
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Info = "Kullanıcı adı ve şifre boş olamaz";
            }
           
           else
            {
                var user = await Userservice.GetUserByUsernameAsync(UserName);
                if (user != null)
                {
                    Info = "Kullanıcı adı zaten kullanımda";
                }
                else
                {
                    var hashedpassword= PasswordManager.HashPassword(Password); // şifreyi hashleyip öyle veritabanına ekliyoruz
                    await Userservice.AddUserAsync(UserName, hashedpassword);
                    Info = "Kullanıcı başarıyla eklendi! Giriş sayfasına dönebilirsiniz";
                }

            } 
            


        }

        



    }
}

