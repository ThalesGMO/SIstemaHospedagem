

using Microsoft.Data.SqlClient;

public class DbConnection
{
    public static void TestaBanco()
    {
        string stringDeConexao = "Server=THALES; Database=SistemaHospedagem; User Id=sa; Password=123;TrustServerCertificate=True";
        SqlConnection conexao = new SqlConnection(stringDeConexao);
        try
        {
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT '1' as Nome", conexao);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                string nome = (string)leitor["Nome"];
                Console.WriteLine(nome);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("erro p krl");
        }
        finally
        {
            conexao.Close();
        }
    }
}