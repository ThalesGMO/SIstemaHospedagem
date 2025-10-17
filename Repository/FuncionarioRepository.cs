using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class FuncionarioRepository
{
    public void Insert(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Funcionarios (IdCargo, IdStatus, Nome, Cpf, Telefone, DataAdmissao)
                                        VALUES (@IdCargo, @IdStatus, @Nome, @Cpf, @Telefone, @DataAdmissao)";
        comando.Parameters.AddWithValue("@IdCargo", funcionario.IdCargo);
        comando.Parameters.AddWithValue("@IdStatus", funcionario.IdCargo);
        comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
        comando.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
        comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
        comando.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Funcuonarios
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", funcionario.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE TABLE Funcionarios 
                                        SET IdCargo = @IdCargo,
                                            IdStatus = @IdStatus,
                                            Nome = @Nome, 
                                            Cpf = @Cpf,
                                            Telefone = @Telefone, 
                                            DataAdmissao = @DataAdmissao
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", funcionario.Id);
        comando.Parameters.AddWithValue("@IdCargo", funcionario.IdCargo);
        comando.Parameters.AddWithValue("@IdStatus", funcionario.IdStatus);
        comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
        comando.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
        comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
        comando.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }
    
    public IEnumerable<Funcionario> Search()
    {
        var funcionarios = new List<Funcionario>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @" SELECT IdCargo,
                                        IdStatus, 
                                        Nome, 
                                        Cpf,
                                        Telefone,
                                        DataAdmissao
                                    WHERE Id = Id";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var funcionario = new Funcionario
                {
                    reader.GetInt32(reader.GetOrdinal()),
                };
            }
        }
    }
}