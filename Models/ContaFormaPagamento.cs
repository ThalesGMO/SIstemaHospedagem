namespace SistemaHospedagem.Models;

public class ContaFormaPagamento(int idConta, int idFormaPagamento, decimal valor, Conta conta, ContaFormaPagamento formaPagamento)
{
    public int IdConta { get; set; } = idConta;

    public int IdFormaPagamento { get; set; } = idFormaPagamento;

    public decimal Valor { get; set; } = valor;

    public Conta Conta { get; set; } = conta;

    public ContaFormaPagamento FormaPagamento { get; set; } = formaPagamento;
}