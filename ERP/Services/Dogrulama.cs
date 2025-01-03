// Kullanıcı adının geçerli olup olmadığını kontrol eden metod
public bool IsValidUsername(string username)
{
    if (string.IsNullOrWhiteSpace(username))
        return false;

    // Kullanıcı adı en az 5 karakter, sadece harf ve rakam içermeli
    string usernamePattern = @"^[a-zA-Z0-9]{5,}$";
    return System.Text.RegularExpressions.Regex.IsMatch(username, usernamePattern);
}
// Telefon numarasının geçerli olup olmadığını kontrol eden metod
public bool IsValidPhoneNumber(string phoneNumber)
{
    if (string.IsNullOrWhiteSpace(phoneNumber))
        return false;

    // Basit bir uluslararası telefon numarası doğrulama regex'i
    string phonePattern = @"^\+?[1-9]\d{1,14}$"; 
    return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, phonePattern);
}
