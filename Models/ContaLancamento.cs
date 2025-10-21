namespace SistemaHospedagem.Models;

public class ContaLancamento
{
    public ContaLancamento() { }
    public ContaLancamento(int id, int idConta, int idProduto, int quantidade, decimal valorUnitarioHistorico)
    {
        Id = id;
        IdConta = idConta;
        IdProduto = idProduto;
        Quantidade = quantidade;
        ValorUnitarioHistorico = valorUnitarioHistorico;
    }

    public int Id { get; set; }
    public int IdConta { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitarioHistorico { get; set; }
}