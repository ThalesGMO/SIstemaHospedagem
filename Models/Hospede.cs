namespace SistemaHospedagem.Models;

public class Hospede(int id, string nome, string email, string telefone, string cpf)
{
    public int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public string Email { get; set; } = email;

    public string Telefone { get; set; } = telefone;

    public string Cpf { get; set; } = cpf;
}