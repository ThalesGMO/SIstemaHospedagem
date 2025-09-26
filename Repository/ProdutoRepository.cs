using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class ProdutoRepository
{
    public void Inserir(Produto produto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
            INSERT INTO Produtos (Nome, IdTipo, Valor) 
                VALUES (@Nome, @IdTipo, @Valor)
        ";
        comando.Parameters.AddWithValue("@Nome", produto.Nome);
        comando.Parameters.AddWithValue("@IdTipo", produto.IdTipo);
        comando.Parameters.AddWithValue("@Valor", produto.Valor);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Produto> Buscar()
    {
        var produtos = new List<Produto>();
        using (SqlConnection dbConnection = DbConnection.GetConnection())
        {
            string sql = "SELECT Id, Nome, IdTipo, Valor FROM Produtos";
            var comando = dbConnection.CreateCommand();
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produto = new Produto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            IdTipo = reader.GetInt16(reader.GetOrdinal("IdTipo")),
                            Valor = reader.GetDecimal(reader.GetOrdinal("Valor"))
                        };
                        produtos.Add(produto);
                    }
                }
            }
        }
        return produtos;
    }

    public void Deletar(Produto produto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
            DELETE FROM Produtos 
                WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", produto.Nome);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Atualizar(Produto produto)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
                UPDATE Produtos 
                    SET Nome = @Nome,
                        IdTipo = @IdTipo,
                        Valor = @Valor
                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", produto.Id);
        comando.Parameters.AddWithValue("@Nome", produto.Nome);
        comando.Parameters.AddWithValue("@IdTipo", produto.IdTipo);
        comando.Parameters.AddWithValue("@Nome", produto.Valor);
    }

    public IEnumerable<Produto> Buscar(string nome)
    {
        var produtos = new List<Produto>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
            SELECT  Id, 
                    Nome, 
                    IdTipo, 
                    Valor
                FROM Produtos
                WHERE Nome LIKE '%'+ @Nome + '%'";
        comando.Parameters.AddWithValue("@Nome", nome);
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var produto = new Produto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                    IdTipo = reader.GetInt16(reader.GetOrdinal("IdTipo")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("Valor"))
                };
                produtos.Add(produto);
            }
        }
        return produtos;
    }
}


