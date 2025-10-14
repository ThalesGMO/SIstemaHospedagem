using Microsoft.Identity.Client;

namespace SistemaHospedagem.Models;

public class Reserva
{
    public Reserva() { }

    public Reserva(int id, int idStatus, int idAcomodacao, int idConta, int idFuncionario, DateOnly dataChekin, DateOnly dataCheckout)
    {
        Id = id;
        IdStatus = idStatus;
        IdAcomodacao = idAcomodacao;
        IdConta = idConta;
        IdFuncionario = idFuncionario;
        DataChekin = dataChekin;
        DataCheckout = dataCheckout;
    }

    public int Id;
    public int IdStatus;
    public int IdAcomodacao;
    public int IdConta;
    public int IdFuncionario;
    public DateOnly DataChekin;
    public DateOnly DataCheckout;
}