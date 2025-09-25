namespace SistemaHospedagem.Models;

public class Funcionario(int id, string nome, string cpf, DateOnly dateNascimento, FuncionarioCargo cargo, FuncionarioCargo perfil, FuncionarioStatus status)
{
    int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public string Cpf { get; set; } = cpf;

    public DateOnly DateNascimento { get; set; } = dateNascimento;

    FuncionarioCargo Cargo { get; set; } = cargo;

    FuncionarioCargo Perfil { get; set; } = perfil;

    FuncionarioStatus Status { get; set; } = status;

}