namespace SistemaHospedagem.Models;

public class FuncionarioNivelAcesso
{
    public FuncionarioNivelAcesso() { }
    public FuncionarioNivelAcesso(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }

    public string Nome { get; set; }

}
