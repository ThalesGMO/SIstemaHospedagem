using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaHospedagem.Models;

public class AcomodacaoStatus(int id, string nome)
{
    public int Id { get; set; } = id;
    public string Nome { get; set; } = nome;
}