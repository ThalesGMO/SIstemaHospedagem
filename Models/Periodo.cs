namespace SistemaHospedagem.Models;

public class Periodo
{
    public Periodo() { }
    public Periodo(int id, string nome,DateOnly dataInicio,DateOnly dataFim, string descricao, int prioridade)
    {
        Id = id;
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Descricao = descricao;
        Prioridade = prioridade;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFim { get; set; }
    public string Descricao { get; set; }
    public int Prioridade { get; set; }
}
