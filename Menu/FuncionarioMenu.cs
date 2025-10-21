using Microsoft.VisualBasic;
using SistemaHospedagem.Models;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.ValueObject;

namespace SistemaHospedagem.Menu;

public class FuncionarioMenu
{
    public void CadastrarFuncionario()
    {
        Funcionario funcionario = new Funcionario() { };
        Console.WriteLine("===========MENU DE CADASTRO DE FUNCIONARIO===========");

        Console.WriteLine("Digite o nome do Funcionário:");
        string nome = Console.ReadLine();
        funcionario.ValidateName(nome);
        Console.Clear();
        funcionario.Nome = nome;

        Console.WriteLine("Digite o telefone do funcionário");
        string numero = Console.ReadLine();
        Telefone telefone = new Telefone(numero);
        telefone.ValidatePhone(numero);
        funcionario.Telefone = telefone;
        Console.Clear();
    

        Console.WriteLine("Digite o Cpf do funcionário");
        string cpf = Console.ReadLine();
    }
}