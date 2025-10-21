using Microsoft.Identity.Client;

namespace SistemaHospedagem.Models;

public class Reserva
{
    public Reserva() { }

    public Reserva(int id, int idStatus, int idAcomodacao, int idConta, int idFuncionario, DateOnly dataCheckin, DateOnly dataCheckout)
    {
        Id = id;
        IdStatus = idStatus;
        IdAcomodacao = idAcomodacao;
        IdConta = idConta;
        IdFuncionario = idFuncionario;
        DataCheckin = dataCheckin;
        DataCheckout = dataCheckout;
    }

    public int Id;
    public int IdStatus;
    public int IdAcomodacao;
    public int IdConta;
    public int IdFuncionario;
    public DateOnly DataCheckin;
    public DateOnly DataCheckout;
}