using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class HospedeRepository
{
    public void inserir(Hospede hospede)
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
}
