using SistemaHospedagem.ValueObject;

namespace SistemaHospedagem.Models;

public class Funcionario
{
    public Funcionario() { }
    public Funcionario(int id, string nome, string cpf, Telefone telefone, DateOnly dataAdmissao, int idCargo, int idStatus)
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
    public Telefone Telefone { get; set; }
    public DateOnly DataAdmissao { get; set; }
    public int IdCargo { get; set; }
    public int IdStatus { get; set; }


    FuncionarioCargo Cargo { get; set; }
    FuncionarioStatus Status { get; set; }

    public string ValidateName(string nome)
    {
        while (string.IsNullOrEmpty(nome) == true)
        {
            Console.WriteLine("Nome não pode ser vazio, tente novamente");
            nome = Console.ReadLine();

        }
        return nome;
    }

     public string GetPhone()
    {
        var numero = Telefone.Numero;
        return numero;
    }


}

