namespace SistemaHospedagem.Models;

public class Periodo(int id, string nome, DateTime dataInicio, DateTime dataFim, string descricao)
{
    public int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public DateTime DataInicio { get; set; } = dataInicio;

    public DateTime DataFim { get; set; } = dataFim;

    public string Descricao { get; set; } = descricao;
}
