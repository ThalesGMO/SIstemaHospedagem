using System.Data.Common;
using Microsoft.Data.SqlClient;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.Models;
using SistemaHospedagem.ValueObject;

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
        comando.CommandText = @" SELECT Id,
                                        IdCargo,
                                        IdStatus, 
                                        Nome, 
                                        Cpf,
                                        Telefone,
                                        DataAdmissao
                                    FROM Funcionarios";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var funcionario = new Funcionario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    IdCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                    IdStatus = reader.GetInt32(reader.GetOrdinal("IdStatus")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                    Telefone = new Telefone(reader.GetString(reader.GetOrdinal("Telefone"))),
                    DataAdmissao = reader.GetDateOnly(reader.GetOrdinal("DataAdmissao")),
                };
                funcionarios.Add(funcionario);
            }
            dbConnection.Close();
            return funcionarios;
        }
    }
    
     public bool TelefoneJaExiste(string telefone)
    {
        var dbconnection = DbConnection.GetConnection();
        var comando = dbconnection.CreateCommand();
        comando.CommandText = @"SELECT CASE 
						            WHEN EXISTS (SELECT 1 
											FROM Funcionarios AS f
											WHERE f.Telefone = @Telefone)	
						            THEN 1 
						            ELSE 0
						            END as TelefoneExist;";
        comando.Parameters.AddWithValue("@Telefone", telefone);
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            int telefoneExist = 0;
            if (reader.Read())
                telefoneExist = reader.GetInt32(reader.GetOrdinal("TelefoneExist"));
            return telefoneExist == 1;
        }
    }
}