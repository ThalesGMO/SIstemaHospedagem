using Microsoft.Data.SqlClient;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class FuncionarioRepository
{
    public void Insert(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Funcionarios (Nome, Cpf, Telefone, DataAdmissao, Cargo, Status)
                                    VALUES  (@Nome, @Cpf, @Telefone, @DataAdmissao, @Cargo, @Status)";
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Funcionarios
                                WHERE Id = @Id";
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Funcionarios
                                    SET Nome = @Nome,
                                        Cpf = @Cpf,
                                        Telefone = @Telefone,
                                        DataAdmissao = @DataAdmissao,
                                        IdStatus = @Status 
                                        IdCargo = @Cargo
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", funcionario.Id);
        comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
        comando.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
        comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
        comando.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);
        comando.Parameters.AddWithValue("@Status", funcionario.IdStatus);
        comando.Parameters.AddWithValue("@Cargo", funcionario.IdCargo);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Funcionario> Search()
    {
        var funcionarios = new List<Funcionario>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  Id,
                                        Nome,
                                        Cpf,
                                        Telefone,
                                        DataAdmissao,
                                        IdStatus,
                                        IdCargo,
                                    FROM Funcionarios";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var funcionario = new Funcionario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
                    DataAdmissao = reader.GetDateOnly(reader.GetOrdinal("DataAdmissao")),
                    IdStatus = reader.GetInt32(reader.GetOrdinal("IdStatus")),
                    IdCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                };
                funcionarios.Add(funcionario);
            }
        }
        dbConnection.Close();
        return funcionarios;
    }
}
