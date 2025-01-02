namespace Proje2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Kayıt formunu göster ve giriş formunu gizle
            RegisterForm.IsVisible = true;
            LoginForm.IsVisible = false;
        }

        // Geri Dön Butonunun Tıklama Olayı
        private void OnGoBackClicked(object sender, EventArgs e)
        {
            // Giriş formunu göster ve kayıt formunu gizle
            RegisterForm.IsVisible = false;
            LoginForm.IsVisible = true;
        }

        // Giriş Butonunun Tıklama Olayı
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifre doğrulama (örnek: hardcoded veriyle)
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "1234") // Örnek doğrulama
            {
                // Doğruysa HomePage'e yönlendir
                 await Navigation.PushAsync(new DashboardPage());
            }
            else
            {
                // Yanlışsa hata mesajı göster
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }
       
        // Show Password butonuna tıklanma olayını işleyin
        
    }
}
