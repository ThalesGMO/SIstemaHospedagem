namespace SistemaHospedagem.Models;

public class RegraDeValor
{
    public RegraDeValor() { }
    public RegraDeValor(int id, string nome, decimal valor, int periodo, int tipoQuarto, int tipoAjuste)
    {
        Id = id;
        Nome = nome;
        Valor = valor;
        Idperiodo = periodo;
        IdtipoQuarto = tipoQuarto;
        IdtipoAjuste = tipoAjuste;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public int Idperiodo { get; set; }
    public int IdtipoQuarto { get; set; }
    public int  IdtipoAjuste { get; set; }

}