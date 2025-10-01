using SistemaHospedagem.Models;

public class Acomodacao
{
    public Acomodacao() { }
    public Acomodacao(int id, int tipoQuartoId, int acomodacoesStatusId, int acomodacoesUnidadeId, string nome, string identificador, int capacidade, AcomodacaoUnidade unidade, AcomodacaoStatus acomodacoesStatus, TipoQuarto tipoQuarto)
    {
        Id = id;
        TipoQuartoId = tipoQuartoId;
        AcomodacoesStatusId = acomodacoesStatusId;
        AcomodacoesUnidadeId = acomodacoesUnidadeId;
        Nome = nome;
        Identificador = identificador;
        Capacidade = capacidade;
        Unidade = unidade;
        AcomodacoesStatus = acomodacoesStatus;
        TipoQuarto = tipoQuarto;
    }

    public int Id { get; set; }
    public int TipoQuartoId { get; set; }
    public int AcomodacoesStatusId { get; set; }
    public int AcomodacoesUnidadeId { get; set; }
    public string Nome { get; set; }
    public string Identificador { get; set; }
    public int Capacidade { get; set; }

    public AcomodacaoUnidade Unidade { get; set; }
    public AcomodacaoStatus AcomodacoesStatus { get; set; }
    public TipoQuarto TipoQuarto { get; set; }
}