namespace SistemaHospedagem.Models;

public class Funcionario
{
    public Funcionario() { }
    public Funcionario(int id, string nome, string cpf, DateOnly dateNascimento, string telefone, DateOnly dataAdmissao, int idCargo, int idStatus)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        DataAdmissao = dataAdmissao;
        IdCargo = idCargo;
        IdStatus = idStatus;
        Telefone = telefone;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public DateOnly DataAdmissao { get; set; }
    public int IdCargo { get; set; }
    public int IdStatus { get; set; }


    FuncionarioCargo Cargo { get; set; }
    FuncionarioStatus Status { get; set; }
}
