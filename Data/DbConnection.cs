

using Microsoft.Data.SqlClient;

public class DbConnection
{
    public static SqlConnection GetConnection()
    {
        string stringDeConexao = "Server=DESKTOP-TFUGHUK; Database=SistemaHospedagem; User Id=sa; Password=123;TrustServerCertificate=True";
        SqlConnection conexao = new SqlConnection(stringDeConexao);
        conexao.Open();
        return conexao;
    }
}