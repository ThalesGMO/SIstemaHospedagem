namespace SistemaHospedagem.Models;

public class Conta(int id, byte idStatus, IEnumerable<ContaLancamento> lancamento)
{
    public int Id { get; set; } = id;

    public byte IdStatus { get; set; } = idStatus;

    public IEnumerable<ContaLancamento> Lancamento { get; set; } = lancamento;

    public IEnumerable<ContaFormaPagamento> FormaPagamento { get; set; } = null!;
}
