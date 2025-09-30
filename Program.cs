using SistemaHospedagem.Enum;
using SistemaHospedagem.Models;
using SistemaHospedagem.Repository;


Console.WriteLine("Cadastrar novo hospede");
Console.WriteLine("1 - Adicionar hospede");
Console.WriteLine("2 - Listar");
Console.WriteLine("3 - Atualizar");
Console.WriteLine("4 - Remover");

bool penis = true;
while (penis)
{
    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1": Cadastrar(); break;
        case "2": Buscar(); break;
    }
}

void Cadastrar()
{
    Console.WriteLine("Digite o Nome do hospede");
    string nome = Console.ReadLine();

    Console.WriteLine("Digite seu Cpf");
    string cpf = Console.ReadLine();

    Console.WriteLine("Digite seu telefone");
    string telefone = Console.ReadLine();

    Console.WriteLine("Digite seu Email");
    string email = Console.ReadLine();

    Hospede hospede = new Hospede
    {
        Nome = nome,
        Cpf = cpf,
        Telefone = telefone,
        Email = email

    };

    HospedeRepository produtoRepository = new HospedeRepository();
    produtoRepository.Inserir(hospede);
    return;
}

void Buscar()
{
    IEnumerable<Hospede> hospedes = HospedeRepository.Buscar();

    if (!hospedes.Any())
    {
        Console.WriteLine("Nenhum hospede para buscar");
        return;
    }

    foreach (Hospede hospede in hospedes)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"ID: {hospede.Id}");
        Console.WriteLine($"Nome: {hospede.Nome}");
        Console.WriteLine($"CPF: {hospede.Cpf}");
        Console.WriteLine($"Telefone: {hospede.Telefone}");
        Console.WriteLine($"Email: {hospede.Email}");
        Console.WriteLine("----------------------------------------");
    }
}
