using Microsoft.Data.SqlClient;

namespace SistemaHospedagem.Models;

public class ContaRepository
{
    public void Insert(Conta conta)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Contas (IdStatus, IdContaLancamento, IdFormaPagamento)
                                        VALUES (@IdStatus, @IdContaLancamento, @IdFormaPagamento)";
        comando.Parameters.AddWithValue("@IdStatus", conta.IdStatus);
        comando.Parameters.AddWithValue("@IdContaLancamento", conta.IdContaLancamento);
        comando.Parameters.AddWithValue("@IdFormaPagamento", conta.IdFormaPagamento);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(Conta conta)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Contas
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(Conta conta)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Contas
                                        SET IdStatus = @IdStatus,
                                            IdContaLancamento = @IdContaLancamento,
                                            IdFormaPagamento = @IdFormaPagamento
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.Parameters.AddWithValue("@Id", conta.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Conta> Search()
    {
        var contas = new List<Conta>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT Id
                                        IdStatus,  
                                        IdContaLancamento, 
                                        IdFormaPagamento 
                                    FROM Contas";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var conta = new Conta
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    IdStatus = reader.GetInt32(reader.GetOrdinal("IdContaStatus")),
                    IdFormaPagamento = reader.GetInt32(reader.GetOrdinal("IdFormaPagamento")),
                };
                contas.Add(conta);
            }
        }
        dbConnection.Close();
        return contas;
    }
}