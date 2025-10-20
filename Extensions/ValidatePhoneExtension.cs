using Microsoft.VisualBasic;
using SistemaHospedagem.Models;
using SistemaHospedagem.Repository;
namespace SistemaHospedagem.Extensions;

public class ValidatePhoneExtension
{
    public static string ValidatePhone(string telefone)
    {
        while (string.IsNullOrEmpty(telefone))
        {
            Console.WriteLine("Telefone não pode vazio, tente novamente");
            telefone = Console.ReadLine();
        }

        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        bool verificarTelefone = funcionarioRepository.TelefoneJaExiste(telefone);
        if (verificarTelefone)
        {
            Console.WriteLine("Telefone já cadastrado no banco, adicione outro telefone");
            telefone = Console.ReadLine();
            ValidatePhone(telefone);
        }
        return telefone;
    }
}