using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class PerfilRepository()
{
    public void Insert(Perfil perfil)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Perfis (NomeUsuario, Senha, Salt, FuncionarioId, Email)
                                    VALUES (@NomeUsuario, @Senha, @Salt, @FuncionarioId, @Email)";
        comando.Parameters.AddWithValue("@NomeUsuario", perfil.NomeUsuario);
        comando.Parameters.AddWithValue("@Senha", perfil.Senha);
        comando.Parameters.AddWithValue("@Salt", perfil.Salt);
        comando.Parameters.AddWithValue("@FuncionarioId", perfil.FuncionarioId);
        comando.Parameters.AddWithValue("@Email", perfil.Email);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Delete(Perfil perfil)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Perfis 
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", perfil.Id);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Update(Perfil perfil)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Perfis 
                                    SET NomeUsuario = @NomeUsuario,
                                        Senha = @Senha,
                                        Salt = @Salt,
                                        FuncionarioId = @FuncionarioId,
                                        Email = @Email
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@NomeUsuario", perfil.NomeUsuario);
        comando.Parameters.AddWithValue("@Senha", perfil.Senha);
        comando.Parameters.AddWithValue("@Salt", perfil.Salt);
        comando.Parameters.AddWithValue("@FuncionarioId", perfil.FuncionarioId);
        comando.Parameters.AddWithValue("@Email", perfil.Email);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Perfil> Search()
    {
        var perfis = new List<Perfil>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT   
                                    Id, 
                                     NomeUsuario,
                                     Senha,
                                     Salt, 
                                     FuncionarioId,
                                     Email,
                                    FROM Perfis";
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var perfil = new Perfil()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    NomeUsuario = reader.GetString(reader.GetOrdinal("NomeUsuario")),
                    Senha = reader.GetString(reader.GetOrdinal("Senha")),
                    Salt = reader.GetString(reader.GetOrdinal("Salt")),
                    FuncionarioId = reader.GetInt32(reader.GetOrdinal("FuncionarioId")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                };
                perfis.Add(perfil);
            }
        }
        dbConnection.Close();
        return perfis;
    }

    public IEnumerable<Perfil> SearchByName(string nome)
    {
        var perfis = new List<Perfil>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT   
                                    Id, 
                                     NomeUsuario,
                                     Senha,
                                     Salt, 
                                     FuncionarioId,
                                     Email,
                                    FROM Perfis";
        comando.Parameters.AddWithValue("Nome", nome);
        using (SqlDataReader reader = comando.ExecuteReader())
        {
            while (reader.Read())
            {
                var perfil = new Perfil()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    NomeUsuario = reader.GetString(reader.GetOrdinal("NomeUsuario")),
                    Senha = reader.GetString(reader.GetOrdinal("Senha")),
                    Salt = reader.GetString(reader.GetOrdinal("Salt")),
                    FuncionarioId = reader.GetInt32(reader.GetOrdinal("FuncionarioId")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                };
                perfis.Add(perfil);
            }
        }
        dbConnection.Close();
        return perfis;
    }
}