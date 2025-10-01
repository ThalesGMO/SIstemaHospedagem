namespace SistemaHospedagem.Models;

public class ContaLancamento
{
    public ContaLancamento() { }
    public ContaLancamento(int id, int idConta, int idProduto, int quantidade, decimal valorUnitarioHistorico, Produto produto)
    {
        Id = id;
        IdConta = idConta;
        IdProduto = idProduto;
        Quantidade = quantidade;
        ValorUnitarioHistorico = valorUnitarioHistorico;
        Produto = produto;
    }

    public int Id { get; set; }
    public int IdConta { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitarioHistorico { get; set; }
    public Produto Produto { get; set; }
}