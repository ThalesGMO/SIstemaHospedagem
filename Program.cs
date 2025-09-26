using SistemaHospedagem.Enum;
using SistemaHospedagem.Models;
using SistemaHospedagem.Repository;


Console.WriteLine("Algo");
Console.WriteLine("1 - Adicionar produto");
Console.WriteLine("2 - Listar");
Console.WriteLine("3 - Atualizar");
Console.WriteLine("4 - Remover");

bool penis = true;
while (penis)
{
    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
                Cadastrar();
            break;
    }
}

void Cadastrar()
{
    Console.WriteLine("Digite o nome do produto");
    string nome = Console.ReadLine();

    var tiposProdutos = Enum.GetValues<ProdutoTiposEnum>().ToList();
    Console.WriteLine("Escolha o tipo desse produto");

    foreach (var tipoProduto in tiposProdutos)
        Console.WriteLine($"{(int)tipoProduto} - {tipoProduto}");
    short tipo = short.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor desse produto");
    decimal valor = decimal.Parse(Console.ReadLine());

    Produto produto = new Produto
    {
        Nome = nome,
        IdTipo = tipo,
        Valor = valor,
    };

    ProdutoRepository produtoRepository = new ProdutoRepository();
    produtoRepository.Inserir(produto);
}
