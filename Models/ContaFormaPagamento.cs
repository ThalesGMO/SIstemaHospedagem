namespace SistemaHospedagem.Models;

public class ContaFormaPagamento
{
    public ContaFormaPagamento() { }
    public ContaFormaPagamento(int idConta, int idFormaPagamento, decimal valor, Conta conta, ContaFormaPagamento formaPagamento)
    {
        IdConta = idConta;
        IdFormaPagamento = idFormaPagamento;
        Valor = valor;
        Conta = conta;
        FormaPagamento = formaPagamento;
    }

    public int IdConta { get; set; }
    public int IdFormaPagamento { get; set; }
    public decimal Valor { get; set; }
    public Conta Conta { get; set; }
    public ContaFormaPagamento FormaPagamento { get; set; }
}