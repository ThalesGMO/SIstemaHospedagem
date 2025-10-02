using SistemaHospedagem.Models;

namespace SistemaHospedagem.Repository;

public class FuncionarioRepository
{
    public void Inserir(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"INSERT INTO Funcionarios (Nome, Cpf, Telefone, DataAdmissao, Cargo, Status)
                                    VALUES  (@Nome, @Cpf, @Telefone, @DataAdmissao, @Cargo, @Status)";
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Deletar(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"DELETE FROM Funcionarios
                                WHERE Id = @Id";
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void Atualizar(Funcionario funcionario)
    {
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"UPDATE Funcionarios
                                    SET Nome = @Nome,
                                        Cpf = @Cpf,
                                        Telefone = @Telefone,
                                        DataAdmissao = @DataAdmissao,
                                        IdStatus = @Status 
                                        IdCargo = @Cargo
                                    WHERE Id = @Id";
        comando.Parameters.AddWithValue("@Id", funcionario.Id);
        comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
        comando.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
        comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
        comando.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);
        comando.Parameters.AddWithValue("@Status", funcionario.IdStatus);
        comando.Parameters.AddWithValue("@Cargo", funcionario.IdCargo);
        comando.ExecuteNonQuery();
        dbConnection.Close();
    }

    public IEnumerable<Funcionario> Buscar()
    {
        var funcionario = new List<Funcionario>();
        var dbConnection = DbConnection.GetConnection();
        var comando = dbConnection.CreateCommand();
        comando.CommandText = @"SELECT  f.Id,
                                        f.Nome,
                                        f.Cpf,
                                        f.Telefone,
                                        f.DataAdmissao,
                                        f.IdStatus,
                                        fs.Nome,
                                        f.IdCargo,
                                        fc.Nome
                                    FROM Funcionarios f
                                            INNER JOIN FuncionariosStatus fs
                                                ON f.IdStatus = fs.Id
                                            INNER JOIN FuncionariosCargos fc
                                                ON f.IdCargo = fc.Id";


    }

}