namespace SistemaHospedagem.Models;

public class RegrasDeValores
{
    public RegrasDeValores() { }
    public RegrasDeValores(int id, string nome, decimal valor, Periodo periodo, TipoQuarto tipoQuarto, TipoAjuste tipoAjuste)
    {
        Id = id;
        Nome = nome;
        Valor = valor;
        this.periodo = periodo;
        this.tipoQuarto = tipoQuarto;
        this.tipoAjuste = tipoAjuste;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public Periodo periodo { get; set; }
    public TipoQuarto tipoQuarto { get; set; }
    public TipoAjuste tipoAjuste { get; set; }

}