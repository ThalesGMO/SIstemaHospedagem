using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class ContaLancamentoRepository
{
    public void Insert(ContaLancamento contaLancamento)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO ContasLancamentos (IdConta, IdProduto, Quantidade, ValorUnitarioHistorico)
                                            VALUES (@IdConta, @IdProduto, @Quantidade, @ValorUnitarioHistorico)";
        comando.Parameters.AddWithValue("@IdConta", contaLancamento.IdConta);
        comando.Parameters.AddWithValue("@IdProduto", contaLancamento.IdProduto);
        comando.Parameters.AddWithValue("@Quantidade", contaLancamento.Quantidade);
        comando.Parameters.AddWithValue("@ValorUnitarioHistorico", contaLancamento.ValorUnitarioHistorico);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }
    public void Update(ContaLancamento contaLancamento)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE TABLE ContasLancamentos
                                        SET IdConta = @IdConta,
                                            IdProduto = @IdProduto,
                                            Quantidade = @Quantidade,
                                            ValorUnitarioHistorico = @ValorUnitarioHistorico
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", contaLancamento.Id);
        comando.Parameters.AddWithValue("@IdConta", contaLancamento.IdConta);
        comando.Parameters.AddWithValue("@IdProduto", contaLancamento.IdProduto);
        comando.Parameters.AddWithValue("@Quantidade", contaLancamento.Quantidade);
        comando.Parameters.AddWithValue("@ValorUnitarioHistorico", contaLancamento.ValorUnitarioHistorico);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(ContaLancamento contaLancamento)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM ContasLancamentos
                                        WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", contaLancamento.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<ContaLancamento> Search()
    {
        var contasLancamentos = new List<ContaLancamento>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  IdConta,
                                            IdProduto, 
                                            Quantidade,
                                            ValorUnitarioHistorico
                                        WHERE Id = @Id";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var contaLancamento = new ContaLancamento()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    IdProduto = reader.GetInt32(reader.GetOrdinal("IdProduto")),
                    IdConta = reader.GetInt32(reader.GetOrdinal("IdConta")),
                    Quantidade = reader.GetInt32(reader.GetOrdinal("Quantidade")),
                    ValorUnitarioHistorico = reader.GetDecimal(reader.GetOrdinal("ValorUnitarioHistorico")),
                };
                contasLancamentos.Add(contaLancamento);
            }
        }
        dbConnection.Close();
        return contasLancamentos;
    }
}
