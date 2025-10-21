namespace SistemaHospedagem.ValueObject;

public class Email
{
    public Email(string email)
    {

        Endereco = email;

    }
    
    public string Endereco;

    public bool ValidateEmail(string email)
    {
        return string.IsNullOrEmpty(email);
    }
}