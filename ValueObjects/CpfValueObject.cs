using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHospedagem.ValueObject;

public class Cpf
{
    public Cpf(string cpf)
    {
        Codigo = cpf;
    }
    public string Codigo;

    public string Validate(string cpf)
    {
        while (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
        {
            Console.WriteLine("Cpf inválido");
            cpf = Console.ReadLine();
        }
        return cpf;
    }
}
