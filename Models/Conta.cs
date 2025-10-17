namespace SistemaHospedagem.Models;

public class Conta
{

    public Conta() { }
    public Conta(int id, byte idStatus, int idContaLancamento, int idFormaPagamento)
    {
        Id = id;
        IdStatus = idStatus;
        IdContaLancamento = idContaLancamento;
        IdFormaPagamento = idFormaPagamento;
    }

    public int Id { get; set; }
    public int IdStatus { get; set; }
    public int IdContaLancamento { get; set; }
    public int  IdFormaPagamento { get; set;}
 
}
