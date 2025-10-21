using System.Globalization;

namespace SistemaHospedagem.Enum;

public class FuncionarioEnum
{
    public void Listar()
    {
        foreach (FuncionarioCargoEnum cargo in System.Enum.GetValues(typeof(FuncionarioCargoEnum)))
        {
            string nomeCargo = cargo.ToString();
            int indexCargo = (int)cargo;
            Console.WriteLine($"{indexCargo} - {nomeCargo}");
        }
    }

    public byte SetEscolhaEnum()
    {
        byte valorCargo;
        Console.Write("CARGO: ");
        while (!byte.TryParse(Console.ReadLine(), out valorCargo) || valorCargo > 8 || valorCargo < 1)
            Console.WriteLine("Entrada inválida, tente novamente");
        return valorCargo; 
    }
}
public enum FuncionarioCargoEnum
{
    Diretor = 1,
    GerenteDepartamento = 2,
    Recepcionista = 3,
    Camareira = 4,
    Limpeza = 5,
    Suporte = 6,
    Cozinha = 7,
}


    

