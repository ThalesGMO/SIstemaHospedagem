using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace SistemaHospedagem.Models;

public class RegraDeValoreRepository
{
    public void Insert(RegraDeValor regraDeValor)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO RegrasDeValores (Nome, Valor, IdPeriodo, idTipoQuarto, IdTipoAjuste)
                                    VALUES (@Nome, @Valor, @IdPeriodo, @IdTipoQuarto, @IdTipoAjuste)";
        comando.Parameters.AddWithValue("@Nome", regraDeValor.Nome);
        comando.Parameters.AddWithValue("@Valor", regraDeValor.Valor);
        comando.Parameters.AddWithValue("@IdPeriodo", regraDeValor.Idperiodo);
        comando.Parameters.AddWithValue("@IdTipoQuarto", regraDeValor.IdtipoQuarto);
        comando.Parameters.AddWithValue("@IdTipoAjuste", regraDeValor.IdtipoAjuste);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(RegraDeValor regraDeValor)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM RegrasDeValores 
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", regraDeValor.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(RegraDeValor regraDeValor)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE RegrasDeValores
                                    SET Nome = @Nome
                                        Valor = @Valor,
                                        IdPeriodo = @IdPeriodo 
                                        IdTipoQuarto = @IdTipoQuarto,
                                        IdTipoAjuste = @IdTipoAjuste
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Nome", regraDeValor.Nome);
        comando.Parameters.AddWithValue("@Valor", regraDeValor.Valor);
        comando.Parameters.AddWithValue("@IdPeriodo", regraDeValor.Idperiodo);
        comando.Parameters.AddWithValue("@IdTipoQuarto", regraDeValor.IdtipoQuarto);
        comando.Parameters.AddWithValue("@IdTipoAjuste", regraDeValor.IdtipoAjuste);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<RegraDeValor> Search()
    {
        var regrasDeValor = new List<RegraDeValor>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT Id,
                                        Nome, 
                                        Valor,
                                        IdPeriodo,
                                        IdTipoQuarto,
                                        IdTipoAjuste
                                    FROM RegrasDeValores";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var regraDeValor = new RegraDeValor()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("Valor")),
                    Idperiodo = reader.GetInt32(reader.GetOrdinal("IdPeriodo")),
                    IdtipoQuarto = reader.GetInt32(reader.GetOrdinal("IdTipoQuarto")),
                    IdtipoAjuste = reader.GetInt32(reader.GetOrdinal("IdTipoAjuste")),
                };
                regrasDeValor.Add(regraDeValor);
            }
        }
        dbConnection.Close();
        return regrasDeValor;
    }
}