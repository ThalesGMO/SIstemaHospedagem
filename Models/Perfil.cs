namespace SistemaHospedagem.Models;

public class Perfil(int id, string nomeUsuario, string senha, string salt, int funcionarioId, Funcionario funcionario)
{
    public int Id { get; set; } = id;

    public string NomeUsuario { get; set; } = nomeUsuario;

    public string Senha { get; set; } = senha;

    public string Salt { get; set; } = salt;

    public int FuncionarioId { get; set; } = funcionarioId;

    public Funcionario Funcionario { get; set; } = funcionario;
}