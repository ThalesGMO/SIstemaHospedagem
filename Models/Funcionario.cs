using SistemaHospedagem.Repository;
using SistemaHospedagem.ValueObject;

namespace SistemaHospedagem.Models;

public class Funcionario
{
    public Funcionario() { }
    public Funcionario(int id, string nome, Cpf cpf, Telefone telefone, DateTime dataAdmissao, byte idCargo, byte idStatus)
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
    public Cpf Cpf { get; set; }
    public Telefone Telefone { get; set; }
    public DateTime DataAdmissao { get; set; }
    public byte IdCargo { get; set; }
    public byte IdStatus { get; set; }


    FuncionarioCargo Cargo { get; set; }
    FuncionarioStatus Status { get; set; }

    public string ValidateName()
    {
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome) == true)
        {
            Console.WriteLine("Nome não pode ser vazio, tente novamente");
            nome = Console.ReadLine();
        }
        return nome;
    }

    public string ValidarNumeroJaExistente(string telefone)
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        bool verificarTelefone = funcionarioRepository.TelefoneJaExiste(telefone);
        while (verificarTelefone)
        {
            Console.WriteLine("Telefone já cadastrado no banco, adicione outro telefone");
            telefone = Console.ReadLine();
            funcionarioRepository.TelefoneJaExiste(telefone);
        }
        return telefone;
    }
    
    public string ValidarCpfJaExistente(string cpf)
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        bool verificarCpf = funcionarioRepository.CpfJaExiste(cpf);
        while (verificarCpf)
        {
            Console.WriteLine("Cpf já cadastrado no banco, adicione outro cpf");
            cpf = Console.ReadLine();
        }
        return cpf;
    }
}

