namespace SistemaHospedagem.Models;

public class FuncionarioStatus
{
    public FuncionarioStatus() { }
    public FuncionarioStatus(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }

    public string Nome { get; set; }
}