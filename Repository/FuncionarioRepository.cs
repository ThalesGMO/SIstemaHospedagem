using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class FuncionarioRepository
{
    public void Insert(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT ";
    }
}