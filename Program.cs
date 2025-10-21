using SistemaHospedagem.Enum;
using SistemaHospedagem.Models;
using SistemaHospedagem.Repository;
using SistemaHospedagem.Menu;
using SistemaHospedagem.Extensions;

// FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
// funcionarioRepository.Search();
// foreach (var Funcionario in funcionarioRepository.Search())
// {
//     Console.WriteLine($"NOME: {Funcionario.Nome}");
//     Console.WriteLine($"CPF: {Funcionario.Cpf.Codigo}");
//     Console.WriteLine($"TELEFONE: {Funcionario.Telefone.Numero}");
// }

FuncionarioMenu menu = new FuncionarioMenu();
menu.Cadastrar();



// Console.WriteLine("Cadastrar novo hospede");
// Console.WriteLine("1 - Adicionar hospede");
// Console.WriteLine("2 - Listar");
// Console.WriteLine("3 - Adicionar Periodo");
// Console.WriteLine("4 - Remover");

// bool loop = true;
// while (loop)
// {
//     string opcao = Console.ReadLine();
//     switch (opcao)
//     {
//         case "1": Cadastrar(); break;
//         case "2": Buscar(); break;
//         case "3": InserirPeriodo(); break;
//     }
// }

// void Cadastrar()
// {
//     Console.WriteLine("Digite o Nome do hospede");
//     string nome = Console.ReadLine();

//     Console.WriteLine("Digite seu Cpf");
//     string cpf = Console.ReadLine();

//     Console.WriteLine("Digite seu telefone");
//     string telefone = Console.ReadLine();

//     Console.WriteLine("Digite seu Email");
//     string email = Console.ReadLine();

//     Hospede hospede = new Hospede
//     {
//         Nome = nome,
//         Cpf = cpf,
//         Telefone = telefone,
//         Email = email

//     };

//     HospedeRepository produtoRepository = new HospedeRepository();
//     produtoRepository.Insert(hospede);
//     return;
// }

// void Buscar()
// {
//     IEnumerable<Hospede> hospedes = HospedeRepository.Search();

//     if (!hospedes.Any())
//     {
//         Console.WriteLine("Nenhum hospede para buscar");
//         return;
//     }

//     foreach (Hospede hospede in hospedes)
//     {
//         Console.WriteLine("----------------------------------------");
//         Console.WriteLine($"ID: {hospede.Id}");
//         Console.WriteLine($"Nome: {hospede.Nome}");
//         Console.WriteLine($"CPF: {hospede.Cpf}");
//         Console.WriteLine($"Telefone: {hospede.Telefone}");
//         Console.WriteLine($"Email: {hospede.Email}");
//         Console.WriteLine("----------------------------------------");
//     }
// }

// void InserirPeriodo()
// {
//     Console.WriteLine("Digite o Nome do Periodo");
//     string nome = Console.ReadLine();

//     Console.WriteLine("Digite a data de início do período");
//     DateOnly dataInicio = DateOnly.Parse(Console.ReadLine());

//     Console.WriteLine("Digite a data de fim do período");
//     DateOnly datafim = DateOnly.Parse(Console.ReadLine());

//     Console.WriteLine("Digite a descricao do período");
//     string descricao = Console.ReadLine();

//     Console.WriteLine("Digite a Prioridade do período");

//     foreach (var prioridade in Enum.GetValues(typeof(PeridoosPrioridadeEnum)))
//         Console.WriteLine($"{prioridade}");
//     int prioridadeEscolhida = int.Parse(Console.ReadLine());

//     Periodo periodo = new Periodo()
//     {
//         Nome = nome,
//         DataInicio = dataInicio,
//         DataFim = datafim,
//         Descricao = descricao,
//         Prioridade = prioridadeEscolhida
//     };

//     PeriodoRepository periodoRepository = new PeriodoRepository();
//     periodoRepository.Insert(periodo);
//     return;
// }

// void InserirFuncionario()
// {
//     Console.WriteLine("Digite o nome do funcionario");
// }
