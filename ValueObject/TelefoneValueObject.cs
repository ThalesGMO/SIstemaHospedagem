using System.ComponentModel;
using SistemaHospedagem.Repository;

namespace SistemaHospedagem.ValueObject;

public class Telefone
{
    public Telefone(string numero)
    {
        Numero = numero;
    }
    public string Numero;

    public string ValidatePhone(string telefone)
    {
        while (string.IsNullOrEmpty(telefone))
        {
            Console.WriteLine("Telefone não pode vazio, tente novamente");
            telefone = Console.ReadLine();
        }
        return telefone;
    }  
}