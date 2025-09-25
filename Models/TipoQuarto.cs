namespace  SistemaHospedagem.Models;

public class TipoQuarto(int id, string nome, decimal precoDiaria)
{
    public int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public decimal PrecoDiaria { get; set; } = precoDiaria;
}