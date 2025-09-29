namespace  SistemaHospedagem.Models;

public class TipoQuarto
{
    TipoQuarto(){}
    public TipoQuarto(int id, string nome, decimal precoDiaria)
    {
        Id = id;
        Nome = nome;
        PrecoDiaria = precoDiaria;
    }

    public int Id { get; set; }

    public string Nome { get; set; } 

    public decimal PrecoDiaria { get; set; } 
}