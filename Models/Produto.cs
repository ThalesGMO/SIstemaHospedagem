namespace SistemaHospedagem.Models;

public class Produto
{
    public Produto() { }
    public Produto(int id, string nome, short idTipo, decimal valor, ProdutoTipo tipo)
    {
        Id = id;
        Nome = nome;
        IdTipo = idTipo;
        Valor = valor;
        Tipo = tipo;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public short IdTipo { get; set; }
    public decimal Valor { get; set; }
    public ProdutoTipo Tipo { get; set; }
}