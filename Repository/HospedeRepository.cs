using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class HospedeRepository
{
    public void Inserir(Hospede hospede)
    {
        var dbConnection = DbConnection.GetConnection();
        var Comando = dbConnection.CreateCommand();
        Comando.CommandText = @"
            INSERT INTO Produtos (Nome, Telefone, Email, Cpf)
                VALUES (@Nome, @Telefone, @Email, @Cpf)
        ";
        Comando.Parameters.AddWithValue("@Nome", hospede.Nome);
        Comando.Parameters.AddWithValue("@Telefone", hospede.Telefone);
        Comando.Parameters.AddWithValue("@Email", hospede.Email);
        Comando.Parameters.AddWithValue("@Cpf", hospede.Cpf);
        Comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Deletar(Hospede hospede)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
            DELETE FROM Produtos 
                WHERE Id = @Id
        ";
        comando.Parameters.AddWithValue("@Id", hospede.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Atualizar(Hospede hospede)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"
            UPDATE Hospedes 
                SET Nome = @Nome
                    Email = @Email
                    Telefone = Telefone
                    Cpf = @Cpf
                WHERE Id = @Id
        ";
        comando.Parameters.AddWithValue("@Nome", hospede.Nome);
        comando.Parameters.AddWithValue("@Email", hospede.Email);
        comando.Parameters.AddWithValue("@Telefone", hospede.Telefone);
        comando.Parameters.AddWithValue("@Cpf", hospede.Cpf);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Hospede> Buscar()
    {
        var hospedes = new List<Hospede>();
        using (SqlConnection dbConnection = DbConnection.GetConnection())
        {
            string sql = @"SELECT   Id
                                    Nome, 
                                    Email, 
                                    Telefone, 
                                    Cpf
                            FROM Hospedes
            ";
            var comando = dbConnection.CreateCommand();
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hospede = new Hospede
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
                            Cpf = reader.GetString(reader.GetOrdinal("Cpf"))
                        };
                        hospedes.Add(hospede);
                    }
                }
            }
        }
        return hospedes;
    }
}