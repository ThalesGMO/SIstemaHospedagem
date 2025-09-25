namespace SistemaHospedagem.Models;

public class Produto(int id, string nome, short idTipo, ProdutoTipo tipo, decimal valor)
{
    public int Id { get; set; } = id;
    public string Nome { get; set; } = nome;
    public short IdTipo { get; set; } = idTipo;
    public ProdutoTipo Tipo { get; set; } = tipo;
    public decimal Valor { get; set; } = valor;
}