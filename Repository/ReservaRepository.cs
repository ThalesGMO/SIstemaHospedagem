using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SistemaHospedagem.Extensions;
using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository
{
    public class ReservaRepository
    {
        public void Insert(Reserva reserva)
        {
            var dbConnection = DbConnection.GetConnection();
            var comando = dbConnection.CreateCommand();
            comando.CommandText = @"INSERT INTO Reservas (IdStatus, IdAcomodacao, IdConta, IdFuncionario, DataCheckin, DataCheckout)
                                            VALUES (@IdStatus, @IdAcomodacao, @IdConta, @IdFuncionario, @DataCheckin, @DataCheckout)";
            comando.Parameters.AddWithValue("@IdStatus", reserva.IdStatus);
            comando.Parameters.AddWithValue("@IdAcomodacao", reserva.IdAcomodacao);
            comando.Parameters.AddWithValue("@IdConta", reserva.IdConta);
            comando.Parameters.AddWithValue("@IdFuncionario", reserva.IdFuncionario);
            comando.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            comando.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            comando.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void Delete(Reserva reserva)
        {
            var dbConnection = DbConnection.GetConnection();
            var comando = dbConnection.CreateCommand();
            comando.CommandText = @"DELETE FROM Reservas 
                                        WHERE Id = @Id";
            comando.Parameters.AddWithValue("@Id", reserva.Id);
            comando.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void Update(Reserva reserva)
        {
            var dbConnection = DbConnection.GetConnection();
            var comando = dbConnection.CreateCommand();
            comando.CommandText = @"UPDATE Reservas
                                        SET IdStatus = @IdStatus,
                                            IdAcomodacao = @IdAcomodacao,
                                            IdConta = @IdConta,
                                            IdFuncionario = @IdFuncionario,
                                            DataCheckin = @DataCheckin,
                                            DataCheckout = @DataCheckout
                                        WHERE Id = @Id";
            comando.Parameters.AddWithValue("@IdStatus", reserva.IdStatus);
            comando.Parameters.AddWithValue("@IdAcomodacao", reserva.IdAcomodacao);
            comando.Parameters.AddWithValue("@IdConta", reserva.IdConta);
            comando.Parameters.AddWithValue("@IdFuncionario", reserva.IdFuncionario);
            comando.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            comando.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            comando.ExecuteNonQuery();
            dbConnection.Close();
        }

        public IEnumerable<Reserva> Search()
        {
            var reservas = new List<Reserva>();
            var dbConnection = DbConnection.GetConnection();
            var comando = dbConnection.CreateCommand();
            comando.CommandText = @"SELECT 
                                        Id,
                                        IdStatus,
                                        IdAcomodacao,
                                        IdConta,
                                        IdFuncionario,
                                        DataCheckin,
                                        DataCheckout
                                    FROM Reservas";
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    var reserva = new Reserva()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        IdStatus = reader.GetInt32(reader.GetOrdinal("IdStatus")),
                        IdAcomodacao = reader.GetInt32(reader.GetOrdinal("IdAcomodacao")),
                        IdConta = reader.GetInt32(reader.GetOrdinal("IdConta")),
                        IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                        DataCheckin = reader.GetDateOnly(reader.GetOrdinal("DataCheckin")),
                        DataCheckout = reader.GetDateOnly(reader.GetOrdinal("DataCheckout")),
                    };
                    reservas.Add(reserva);
                }
            }
            dbConnection.Close();
            return reservas; 
        }
    }
}