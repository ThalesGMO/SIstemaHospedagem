namespace SistemaHospedagem.Models;

public class TipoQuarto
{
    public TipoQuarto() { }
    public TipoQuarto(int id, string nome, decimal valorDiaria)
    {
        Id = id;
        Nome = nome;
        ValorDiaria = valorDiaria;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal ValorDiaria { get; set; }
}