namespace SistemaHospedagem.Models;

public class ContaStatus
{
    public ContaStatus() { }
    public ContaStatus(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }

    public string Nome { get; set; }
}