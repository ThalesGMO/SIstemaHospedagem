using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaHospedagem.Models;

[Table(nameof(AcomodacaoStatus))]
public class AcomodacaoStatus(int id, string nome)
{
    [Key]
    [Column(nameof(Id))]
    public int Id { get; set; } = id;

    [Required]
    [MaxLength(50)]
    [Column(nameof(Nome))]
    public string Nome { get; set; } = nome;
}