using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;
using SistemaHospedagem.Models;

public class AcomodacaoUnidade
{
    public AcomodacaoUnidade() { }
    public AcomodacaoUnidade(int id, string nome, int cep, string logradouro, string numero, string complemento, string bairro, string cidade, string estado)
    {
        Id = id;
        Nome = nome;
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}