using ERP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        private string _email;
        private string _info;

        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        public string Info
        {
            get => _info;
            set => SetProperty(ref _info, value);
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
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname))
            {
                Info = "Formun tamamını doldurmalısınız!";
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
                    var newUser = new Models.User()
                    {
                        Username = UserName,
                        PasswordHash = hashedpassword,
                        Email = this.Email,
                        Surname = this.Surname,
                        Name = this.Name
                    };


                    await Userservice.AddUserAsync(newUser);    
                    Info = "Kullanıcı başarıyla eklendi! Giriş sayfasına dönebilirsiniz";
                }

           } 
            

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

