using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaHospedagem.Models;

public class AcomodacaoStatus
{
    public AcomodacaoStatus() { }
    public AcomodacaoStatus(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}