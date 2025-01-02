namespace ERP.Services
{
    public class ValidationService
    {
       
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailChecker = new System.Net.Mail.MailAddress(email);
                return emailChecker.Address == email;
            }
            catch
            {
                return false;
            }
        }

       
        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

           
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|<>])(?=.*[0-9]).{8,}$";

            return System.Text.RegularExpressions.Regex.IsMatch(password, passwordPattern);
        }
    }
}
