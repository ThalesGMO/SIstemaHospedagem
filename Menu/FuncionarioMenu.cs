using Microsoft.VisualBasic;
using SistemaHospedagem.Models;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.ValueObject;

namespace SistemaHospedagem.Menu;

public class FuncionarioMenu
{
    public void Cadastrar()
    {
        Funcionario funcionario = new Funcionario();
        Console.WriteLine("===========MENU DE CADASTRO DE FUNCIONARIO===========");

        Console.WriteLine("Digite o nome do funcionário:");
        string nome = Console.ReadLine();
        funcionario.ValidateName(nome);
        funcionario.Nome = nome;
        Console.Clear();

        Console.WriteLine("Digite o telefone do funcionário:");
        string numero = Console.ReadLine();
        Telefone telefone = new Telefone(numero);
        telefone.ValidatePhone(numero);
        funcionario.ValidarNumeroJaExistente(numero);
        funcionario.Telefone = telefone;
        Console.Clear();

        Console.WriteLine("Digite o Cpf do funcionário");
        string cpf = Console.ReadLine();
    }
}