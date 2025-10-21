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

    public void Validate(string cpf)
    {
        while (string.IsNullOrEmpty(cpf))
        {
            Console.WriteLine("Cpf inválido, o campo não pode ser vazio");
            cpf = Console.ReadLine();
        }
        
    }
}
