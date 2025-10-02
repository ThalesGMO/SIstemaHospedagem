using Microsoft.Data.SqlClient;

namespace SistemaHospedagem.Repository;

public class AcomodacaoUnidadeRepository
{
    public void Inserir(AcomodacaoUnidade acomodacaoUnidade)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Unidades (Nome, Cep, Logradouro, Numero, Bairro, Cidade, Complemento)
                                Values (@Nome, @Cep, @Logradouro, @Numero, @Bairro, @Cidade, @Complemento)
                                ";
        comando.Parameters.AddWithValue("@Nome", acomodacaoUnidade.Nome);
        comando.Parameters.AddWithValue("@Cep", acomodacaoUnidade.Cep);
        comando.Parameters.AddWithValue("@Logradouro", acomodacaoUnidade.Logradouro);
        comando.Parameters.AddWithValue("@Numero", acomodacaoUnidade.Numero);
        comando.Parameters.AddWithValue("@Bairro", acomodacaoUnidade.Bairro);
        comando.Parameters.AddWithValue("@Cidade", acomodacaoUnidade.Cidade);
        comando.Parameters.AddWithValue("@Complemento", acomodacaoUnidade.Complemento);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Deletar(AcomodacaoUnidade acomodacaoUnidade)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @" DELETE FROM AcomodacaoUnidade
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", acomodacaoUnidade.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Atualizar(AcomodacaoUnidade acomodacaoUnidade)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE AcomodacoesUnidades
                                    SET Nome = @Nome,
                                        Cep = @Cep,
                                        Logradouro = @Logradouro,
                                        Numero = @Numero,
                                        Cidade = @Cidade,
                                       Complemento = @Complemento
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", acomodacaoUnidade.Id);
        comando.Parameters.AddWithValue("@Cep", acomodacaoUnidade.Cep);
        comando.Parameters.AddWithValue("@Logradouro", acomodacaoUnidade.Logradouro);
        comando.Parameters.AddWithValue("@Numero", acomodacaoUnidade.Numero);
        comando.Parameters.AddWithValue("@Cidade", acomodacaoUnidade.Cidade);
        comando.Parameters.AddWithValue("@Complemento", acomodacaoUnidade.Complemento);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<AcomodacaoUnidade> Buscar()
    {
        var acomodacoesUnidades = new List<AcomodacaoUnidade>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  Id
                                        Cep
                                        Logradouro
                                        Numero
                                        Cidade
                                        Complemento
                                    FROM AcomodacoesStatus
                                ";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var acomodacaoUnidade = new AcomodacaoUnidade
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Cep = reader.GetString(reader.GetOrdinal("Cep")),
                    Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")),
                    Numero = reader.GetString(reader.GetOrdinal("Numero")),
                    Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                    Complemento = reader.GetString(reader.GetOrdinal("Complemento")),
                };
                acomodacoesUnidades.Add(acomodacaoUnidade);
            }
        }
        dbConnection.Close();
        return acomodacoesUnidades;
    }
}