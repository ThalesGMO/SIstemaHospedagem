using Microsoft.Data.SqlClient;

namespace SistemaHospedagem.Extensions;

public static class SqlDataReaderExtensions
{
    public static DateOnly GetDateOnly(this SqlDataReader reader, int field)
    {
        return reader.GetFieldValue<DateOnly>(field);
    }


    public stati
}
