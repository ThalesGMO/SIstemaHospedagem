namespace SistemaHospedagem.Models;

public class Perfil
{
    public Perfil() { }
    public Perfil(int id, string nomeUsuario, string senha, string salt, int funcionarioId, string email)
    {
        Id = id;
        NomeUsuario = nomeUsuario;
        Senha = senha;
        Salt = salt;
        FuncionarioId = funcionarioId;
        Email = email;
    }

    public int Id { get; set; }
    public string NomeUsuario { get; set; }
    public string Senha { get; set; }
    public string Salt { get; set; }
    public int FuncionarioId { get; set; }
    public string Email { get; set; }
} 
