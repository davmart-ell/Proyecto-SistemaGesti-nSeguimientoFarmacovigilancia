using System.Data;
using Microsoft.Data.SqlClient;
namespace SANNA.Datos;

public static class Conexion
{
    // Cambie el servidor según su instalación (ej.: .\SQLEXPRESS)
    public static string Cadena { get; set; } =
        "Server=localhost;Database=FarmacovigilanciaSANNA;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlCommand Comando(SqlConnection cn, string sp, params (string, object)[] ps)
    {
        var cmd = new SqlCommand(sp, cn) { CommandType = CommandType.StoredProcedure };
        foreach (var (n, v) in ps) cmd.Parameters.AddWithValue(n, v ?? DBNull.Value);
        return cmd;
    }
}
