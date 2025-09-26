namespace SistemaHospedagem.Models;

public class Produto
{
    public int Id { get; set; } 
    public string Nome { get; set; } 
    public short IdTipo { get; set; } 
    public decimal Valor { get; set; } 


    public ProdutoTipo Tipo { get; set; } 
}