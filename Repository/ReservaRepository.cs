using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            comando.Parameters.AddWithValue("@IdStatus", reserva.IdAcomodacao);
            comando.Parameters.AddWithValue("@IdStatus", reserva.IdConta);
            comando.Parameters.AddWithValue("@IdStatus", reserva.IdFuncionario);
            comando.Parameters.AddWithValue("@IdStatus", reserva.DataCheckin);
            comando.Parameters.AddWithValue("@IdStatus", reserva.DataCheckout);
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
    }
}