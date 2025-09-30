namespace SistemaHospedagem.Models;

public class Funcionario
{
    public Funcionario() { }
    public Funcionario(int id, string nome, string cpf, DateOnly dateNascimento, FuncionarioCargo cargo, FuncionarioCargo perfil, FuncionarioStatus status)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        DateNascimento = dateNascimento;
        Cargo = cargo;
        Perfil = perfil;
        Status = status;
    }

    int Id { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }

    public DateOnly DateNascimento { get; set; }

    FuncionarioCargo Cargo { get; set; }

    FuncionarioCargo Perfil { get; set; }

    FuncionarioStatus Status { get; set; }

}