using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class HospedeRepository
{
    public void Inserir(Hospede hospede)
    {
        var dbConnection = DbConnection.GetConnection();
        var Comando = dbConnection.CreateCommand();
        Comando.CommandText = @"
            INSERT INTO Hospedes (Nome, Telefone, Email, Cpf)
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

    public static IEnumerable<Hospede> Buscar()
    {
        var hospedes = new List<Hospede>();
        using (SqlConnection dbConnection = DbConnection.GetConnection())
        {
            var comando = dbConnection.CreateCommand();
            comando.CommandText = @" SELECT  Id,
                                    Nome,
                                    Cpf,
                                    Telefone, 
                                    Email
                                FROM Hospedes";
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    var hospede = new Hospede
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                        Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                    };
                    hospedes.Add(hospede);
                }
            }
            dbConnection.Close();
        }
        return hospedes;

    }

    public void Atualizar(Hospede hospede)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Hospedes
                                    SET Nome = @Nome
                                        Cpf = @Cpf
                                        Telefone = @Telefone
                                        Email = @Email 
                                WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", hospede.Id);
        comando.Parameters.AddWithValue("@Nome", hospede.Nome);
        comando.Parameters.AddWithValue("@Telefone", hospede.Telefone);
        comando.Parameters.AddWithValue("@Email", hospede.Email);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }
}
