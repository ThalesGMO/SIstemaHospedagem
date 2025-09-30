namespace SistemaHospedagem.Models;

public class Periodo
{
    public Periodo() { }
    public Periodo(int id, string nome, DateTime dataInicio, DateTime dataFim, string descricao)
    {
        Id = id;
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Descricao = descricao;
    }

    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public string Descricao { get; set; }
}
