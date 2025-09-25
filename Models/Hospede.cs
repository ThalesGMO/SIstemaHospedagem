namespace SistemaHospedagem.Models;

public class Hospede
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    
}