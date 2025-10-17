namespace SistemaHospedagem.ValueObject;

public class Email
{
    public Email(string email)
    {
        EmailString = email;

    }
    public string EmailString;

    public bool ValidateEmail(string email)
    {
        return string.IsNullOrEmpty(email);
    }
}