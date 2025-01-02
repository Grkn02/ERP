using ERP.Models;
using ERP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace ERP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
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

        public LoginViewModel(IUserService Userservice)
        {
            this.Userservice = Userservice;
            ButtonClickCommand = new Command(OnButtonClick); // Command'e bir metod bağlanıyor
            RouteRegisterCommand = new Command(OnRegisterClick); // Command'e bir metod bağlanıyor

        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnButtonClick()
        {

            User user  = await Userservice.GetUserByUsernameAsync(UserName);
           
            if (user != null) // kullanıcı adı eşleştiyse
            {
               bool isYou =  PasswordManager.VerifyPassword(Password, user.PasswordHash);
                if (isYou) // şifre de doğruysa
                {
                    UserName = string.Empty;
                    Password = string.Empty;
                    Info = string.Empty;

                    var name = user.Name;
                    var surname = user.Surname;

                    await Shell.Current.GoToAsync("//MainPage"); // geri dönüş olmaması için "//" ekledik!!!
                    await Shell.Current.GoToAsync($"//MainPage?Name={Uri.EscapeDataString(name)}&Surname={Uri.EscapeDataString(surname)}");


                }
                else Info = "Hata: Yanlış Kullanıcı adı veya şifre";
            }
            else Info = "Hata: Yanlış Kullanıcı adı veya şifre";

        }

        private async void OnRegisterClick()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Info = string.Empty;
            await Shell.Current.GoToAsync("RegisterPage");
           

        }



    }


}
