namespace SistemaHospedagem.Models;

public class ProdutoTipo
{
    public ProdutoTipo() { }
    public ProdutoTipo(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}