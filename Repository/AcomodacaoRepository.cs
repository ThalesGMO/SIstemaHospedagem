using Microsoft.Data.SqlClient;

namespace SistemaHospedagem.Repository;

public class AcomodacaoRepository
{
    public void Insert(Acomodacao acomodacao)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Acomodacoes VALUES(TipoQuartoId, IdStatus, IdUnidade, Identificador, Capacidade)
                                        VALUES (@TipoQuartoId, @IdStatus, @IdUnidade, @Identificador, @Capacidade)";
        comando.Parameters.AddWithValue("@TipoQuartoId", acomodacao.TipoQuartoId);
        comando.Parameters.AddWithValue("@IdStatus", acomodacao.AcomodacoesStatusId);
        comando.Parameters.AddWithValue("@IdUnidade", acomodacao.AcomodacoesUnidadeId);
        comando.Parameters.AddWithValue("@Identificador", acomodacao.Identificador);
        comando.Parameters.AddWithValue("@Capacidade", acomodacao.Capacidade);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(Acomodacao acomodacao)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE TABLE Acomodacoes 
                                        SET TipoQuartoId = @TipoQuartoId, 
                                            AcomodacoesStatusId = @AcomodacoesStatusId, 
                                            AcomodacoesUnidadeId = @AcomodacoesUnidadeId, 
                                            Nome = @Nome, 
                                            Identificador = @Identificador, 
                                            Capacidade =  @Capacidade
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@TipoQuartoId", acomodacao.TipoQuartoId);
        comando.Parameters.AddWithValue("@IdStatus", acomodacao.AcomodacoesStatusId);
        comando.Parameters.AddWithValue("@IdUnidade", acomodacao.AcomodacoesUnidadeId);
        comando.Parameters.AddWithValue("@Identificador", acomodacao.Identificador);
        comando.Parameters.AddWithValue("@Capacidade", acomodacao.Capacidade);
        comando.Parameters.AddWithValue("@Id", acomodacao.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(Acomodacao acomodacao)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Acomodacoes
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", acomodacao.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Acomodacao> Search()
    {
        var acomodacoes = new List<Acomodacao>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT Id,
                                        IdTipoAcomodacao, 
                                        IdStatus, 
                                        IdUnidade, 
                                        Identificador, 
                                        Capacidade
                                    FROM Acomodacoes";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var acomodacao = new Acomodacao()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    TipoQuartoId = reader.GetInt32(reader.GetOrdinal("IdTipoAcomodacao")),
                    AcomodacoesStatusId = reader.GetInt32(reader.GetOrdinal("IdStatus")),
                    AcomodacoesUnidadeId = reader.GetInt32(reader.GetOrdinal("IdUnidade")),
                    Identificador = reader.GetString(reader.GetOrdinal("Identificador")),
                    Capacidade = reader.GetInt32(reader.GetOrdinal("Capacidade")),
                };
                acomodacoes.Add(acomodacao);
            }
        }
        dbConnection.Close();
        return acomodacoes;
    }
}