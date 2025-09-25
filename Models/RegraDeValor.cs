namespace SistemaHospedagem.Models;

public class RegrasDeValores(int id, string nome, decimal valor, Periodo periodo, TipoQuarto tipoQuarto, TipoAjuste tipoAjuste)
{
    public int Id { get; set; } = id;

    public string Nome { get; set; } = nome;

    public decimal Valor { get; set; } = valor;

    public Periodo periodo { get; set; } = periodo;

    public TipoQuarto tipoQuarto { get; set; } = tipoQuarto;

    public TipoAjuste tipoAjuste { get; set; } = tipoAjuste;

}