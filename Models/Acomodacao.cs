using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;
using SistemaHospedagem.Models;

[Table(nameof(Acomodacao))]
public class Acomodacao(int id, int tipoQuartoId, TipoQuarto tipoQuarto, int acomodacoesStatusId, AcomodacaoStatus acomodacoesStatus, string nome, string identificador, int capacidade, AcomodacaoUnidade unidade, int acomodacoesUnidadeId)
{
    [Key]
    public int Id { get; set; } = id;

    [ForeignKey(nameof(TipoQuartoId))]
    [Required]
    public int TipoQuartoId { get; set; } = tipoQuartoId;

    [ForeignKey(nameof(AcomodacoesStatusId))]
    [Required]
    public int AcomodacoesStatusId { get; set; } = acomodacoesStatusId;

    [ForeignKey(nameof(AcomodacoesUnidadeId))]
    [Required]
    public int AcomodacoesUnidadeId { get; set; } = acomodacoesUnidadeId;

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = nome;

    [Required]
    [MaxLength(100)]
    public string Identificador { get; set; } = identificador;

    [Required]
    public int Capacidade { get; set; } = capacidade;

    public AcomodacaoUnidade Unidade { get; set; } = unidade;
    public AcomodacaoStatus AcomodacoesStatus { get; set; } = acomodacoesStatus;
    public TipoQuarto TipoQuarto { get; set; } = tipoQuarto;
}