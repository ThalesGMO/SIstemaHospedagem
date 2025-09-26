namespace SistemaHospedagem.Models;

public class Conta
{

    public Conta() { }
    public Conta(int id, byte idStatus, IEnumerable<ContaLancamento> lancamento, IEnumerable<ContaFormaPagamento> formaPagamento)
    {
        Id = id;
        IdStatus = idStatus;
        Lancamento = lancamento;
        FormaPagamento = formaPagamento;
    }

    public int Id { get; set; }
    public byte IdStatus { get; set; }
    public IEnumerable<ContaLancamento> Lancamento { get; set; }
    public IEnumerable<ContaFormaPagamento> FormaPagamento { get; set; }
}
