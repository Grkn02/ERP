
using ERP.Views;
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
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonClickCommand { get; }

        private string _name;
        private string _surname;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(WelcomeMessage)); // Name değiştikçe WelcomeMessage'ı güncelle
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    OnPropertyChanged(nameof(WelcomeMessage)); // Surname değiştikçe WelcomeMessage'ı güncelle
                }
            }
        }

        public string WelcomeMessage => $"Hoşgeldiniz {Name} {Surname}";

        public MainViewModel() 
        {
            ButtonClickCommand = new Command<string>(OnButtonClick);

        }

        private async void OnButtonClick(string buttonMenu )
        {
            if (buttonMenu == nameof(LoginPage))  await Shell.Current.GoToAsync("//"+buttonMenu) ; // çıkış yapırken menüye geri dönüş yapılmasın die ekledik
            else await Shell.Current.GoToAsync(buttonMenu);
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
