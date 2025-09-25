namespace SistemaHospedagem.Models;

public class ContasFormaPagamento(int id, string nome)
{
    public int Id { get; set; } = id;

    public required string Nome { get; set; } = nome;
}