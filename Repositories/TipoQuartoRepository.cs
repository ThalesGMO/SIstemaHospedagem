using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class TipoQuartoRepository
{
    public void Insert(TipoQuarto tipoQuarto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO TiposQuartos (Nome, ValorDiaria)
                                    VALUES (@Nome, @ValorDiaria)";
        comando.Parameters.AddWithValue("@Nome", tipoQuarto.Nome);
        comando.Parameters.AddWithValue("@Nome", tipoQuarto.ValorDiaria);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(TipoQuarto tipoQuarto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM TiposQuartos
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue(@"Id", tipoQuarto.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(TipoQuarto tipoQuarto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE TiposQuartos
                                    SET Nome = @Nome,
                                        ValorDiaria = @ValorDiaria
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Nome", tipoQuarto.Nome);
        comando.Parameters.AddWithValue("@ValorDiaria", tipoQuarto.ValorDiaria);
        comando.Parameters.AddWithValue("@Id", tipoQuarto.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<TipoQuarto> Search()
    {
        var tiposQuartos = new List<TipoQuarto>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  Id,
                                        Nome,
                                        ValorDiaria,
                                    FROM TiposQuartos";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var tipoQuarto = new TipoQuarto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    ValorDiaria = reader.GetDecimal(reader.GetOrdinal("ValorDiaria"))
                };
                tiposQuartos.Add(tipoQuarto);
            }
        }
        dbConnection.Close();
        return tiposQuartos;
    }

    public IEnumerable<TipoQuarto> SearchByName(string nome)
    {
        var tiposQuartos = new List<TipoQuarto>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  Id,
                                        Nome,
                                        ValorDiaria,
                                    FROM TiposQuartos
                                    WHERE Nome LIKE '%'+ @Nome + '%'";
        comando.Parameters.AddWithValue("@Nome", nome);
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var tipoQuarto = new TipoQuarto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    ValorDiaria = reader.GetDecimal(reader.GetOrdinal("ValorDiaria"))
                };
                tiposQuartos.Add(tipoQuarto);
            }
        }
        dbConnection.Close();
        return tiposQuartos;
    }
}