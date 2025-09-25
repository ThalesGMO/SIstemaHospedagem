namespace SistemaHospedagem.Models;

public class ContaLancamento(int id, int idConta, int IdProduto, int quantidade, decimal valorUnitarioHistorico, Produto produto)
{
    public int Id { get; set; } = id;

    public int IdConta { get; set; } = idConta;

    public int IdProduto { get; set; } = produto.Id;

    public int Quantidade { get; set; } = quantidade;

    public decimal ValorUnitarioHistorico { get; set; } = valorUnitarioHistorico;
    
    public Produto Produto { get; set; } = produto;
}