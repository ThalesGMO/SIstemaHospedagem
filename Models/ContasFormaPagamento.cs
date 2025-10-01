namespace SistemaHospedagem.Models;

public class ContasFormaPagamento
{
    public ContasFormaPagamento() { }
    public ContasFormaPagamento(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public required string Nome { get; set; }
}