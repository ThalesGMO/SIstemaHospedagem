using Microsoft.VisualBasic;
using SistemaHospedagem.Models;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.ValueObject;
using SistemaHospedagem.Enum;
using System.Globalization;
using FuncionarioStatus = SistemaHospedagem.Enum.FuncionarioStatus;
using SistemaHospedagem.Repository;

namespace SistemaHospedagem.Menu;

public class FuncionarioMenu
{
    public void Cadastrar()
    {
        Funcionario funcionario = new Funcionario();
        Console.WriteLine("===========MENU DE CADASTRO DE FUNCIONARIO===========");

        Console.Write("Digite o nome do funcionário:");
        funcionario.Nome = funcionario.ValidateName();
        Console.Clear();

        Console.Write("Digite o telefone do funcionário:");
        string numero = Console.ReadLine();
        Telefone telefone = new Telefone(numero);
        telefone.ValidatePhone(numero);
        funcionario.ValidarNumeroJaExistente(numero);
        funcionario.Telefone = telefone;
        Console.Clear();

        Console.Write("Digite o Cpf do funcionário:");
        string codigo = Console.ReadLine();
        Cpf cpf = new Cpf(codigo);
        cpf.Validate(codigo);
        funcionario.ValidarCpfJaExistente(codigo);
        funcionario.Cpf = cpf;
        Console.Clear();

        Console.WriteLine("Digite o número referente ao cargo do funcionário:");
        FuncionarioEnum cargo = new FuncionarioEnum();
        cargo.Listar();
        funcionario.IdCargo = cargo.SetEscolhaEnum();
        Console.Clear();

        Console.WriteLine("Digite o número referente ao Status do funcionário:");
        FuncionarioStatus status = new FuncionarioStatus();
        status.Listar();
        funcionario.IdStatus = status.SetEscolhaEnum();
        Console.Clear();

        DateTime data = DateTime.Now.Date;
        funcionario.DataAdmissao = data;

        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        funcionarioRepository.Insert(funcionario);
        

       
        







    }
}