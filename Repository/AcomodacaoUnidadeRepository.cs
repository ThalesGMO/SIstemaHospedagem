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
         
    }
}