using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaHospedagem.Models;

[Table(nameof(AcomodacaoUnidade))]
public class AcomodacaoUnidade(int id, string nome, int cep, string logradouro, string numero, string complemento, string bairro, string cidade)
{
    [Key]
    [Column(nameof(Id))]
    public int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public int Cep { get; set; } = cep;

    public string Logradouro { get; set; } = logradouro;

    public string Numero { get; set; } = numero;

    public string Complemento { get; set; } = complemento;

    public string Bairro { get; set; } = bairro;

    public string Cidade { get; set; } = cidade;
}