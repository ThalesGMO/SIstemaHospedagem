namespace SistemaHospedagem.Enum;


public class FuncionarioStatus
{
    public void Listar()
    {
        foreach (FuncionarioStatusEnum status in System.Enum.GetValues(typeof(FuncionarioStatusEnum)))
        {
            string nomeStaus = status.ToString();
            int indexStatus = (int)status;
            Console.WriteLine($"{indexStatus} - {nomeStaus}");
        }
    }

    public byte SetEscolhaEnum()
    {
        Console.Write("STATUS: ");
        byte valor;
        while (!byte.TryParse(Console.ReadLine(), out valor) || valor > 3 || valor < 1)
            Console.WriteLine("Entrada inválida, tente novamente");
        return valor; 
    }
}
public enum FuncionarioStatusEnum
{
    Disponivel = 1,
    Indisponivel = 2,
    Bloqueado = 3,
}
    

