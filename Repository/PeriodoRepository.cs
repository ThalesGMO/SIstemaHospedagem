using Microsoft.Data.SqlClient;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class PeriodoRepository
{
    public void Inserir(Periodo periodo)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Periodos (Nome, DataInicio, DataFim, Descricao, Prioridade)
                                VALUES (@Nome, @DataInicio, @DataFim, @Descricao, @Prioridade)";
        comando.Parameters.AddWithValue("@Nome", periodo.Nome);
        comando.Parameters.AddWithValue("@DataInicio", periodo.DataInicio);
        comando.Parameters.AddWithValue("@DataFim", periodo.DataFim);
        comando.Parameters.AddWithValue("@Descricao", periodo.Descricao);
        comando.Parameters.AddWithValue("@Prioridade", periodo.Prioridade);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Deletar(Periodo periodo)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Periodos
                                WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", periodo.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public static IEnumerable<Periodo> Buscar()
    {
        var periodos = new List<Periodo>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  Id 
                                        Nome
                                        DataInicio
                                        DataFim
                                        Descricao
                                        Prioridade
                                    FROM Periodos";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var periodo = new Periodo
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    DataInicio = reader.GetDateOnly(reader.GetOrdinal("DataInicio")),
                    DataFim = reader.GetDateOnly(reader.GetOrdinal("DataFim")),
                    Prioridade = reader.GetInt32(reader.GetOrdinal("Prioridade"))
                };
                periodos.Add(periodo);
            }
        }
        return periodos;
    }

    public void Atualizar(Periodo periodo)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Periodos 
                                    SET Nome = @Nome,
                                        DataInicio = @Datainicio,
                                        DataFim = @DataFim,
                                        Prioridade = @Prioridade
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", periodo.Id);
        comando.Parameters.AddWithValue("@Nome", periodo.Nome);
        comando.Parameters.AddWithValue("@DataInicio", periodo.DataInicio);
        comando.Parameters.AddWithValue("@DataFim", periodo.DataFim);
        comando.Parameters.AddWithValue("@Prioridade", periodo.Prioridade);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }
}
