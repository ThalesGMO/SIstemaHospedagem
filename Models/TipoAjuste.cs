namespace SistemaHospedagem.Models;

public class TipoAjuste
{
    public TipoAjuste() { }
    public TipoAjuste(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}