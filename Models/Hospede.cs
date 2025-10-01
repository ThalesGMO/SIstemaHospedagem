namespace SistemaHospedagem.Models;

public class Hospede
{
    public Hospede() { }
    public Hospede(int id, string nome, string email, string telefone, string cpf)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cpf = cpf;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
}