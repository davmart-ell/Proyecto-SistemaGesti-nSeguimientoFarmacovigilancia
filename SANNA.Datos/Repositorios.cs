using Microsoft.Data.SqlClient;
using SANNA.Entidades;
namespace SANNA.Datos;

public static class UsuarioDatos
{
    public static Usuario Obtener(string nombre)
    {
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Usuario_Obtener", ("@NombreUsuario", nombre));
        cn.Open(); using var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        return new Usuario { IdUsuario = (int)dr["IdUsuario"], NombreUsuario = (string)dr["NombreUsuario"],
            ClaveHash = (byte[])dr["ClaveHash"], ClaveSal = (byte[])dr["ClaveSal"], Rol = (string)dr["Rol"], Activo = (bool)dr["Activo"] };
    }
}

public static class PacienteDatos
{
    public static List<Paciente> Listar(string filtro)
    {
        var l = new List<Paciente>();
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Paciente_Listar", ("@Filtro", filtro ?? ""));
        cn.Open(); using var dr = cmd.ExecuteReader();
        while (dr.Read()) l.Add(new Paciente { IdPaciente = (int)dr["IdPaciente"], NroDocumento = (string)dr["NroDocumento"],
            Apellidos = (string)dr["Apellidos"], Nombres = (string)dr["Nombres"], FechaNacimiento = (DateTime)dr["FechaNacimiento"],
            Sexo = ((string)dr["Sexo"]).Trim(), Telefono = dr["Telefono"] as string, Activo = (bool)dr["Activo"] });
        return l;
    }
    public static int Guardar(Paciente p, int idUsuario)
    {
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Paciente_Guardar", ("@IdPaciente", p.IdPaciente), ("@NroDocumento", p.NroDocumento),
            ("@Apellidos", p.Apellidos), ("@Nombres", p.Nombres), ("@FechaNacimiento", p.FechaNacimiento), ("@Sexo", p.Sexo),
            ("@Telefono", p.Telefono), ("@IdUsuario", idUsuario));
        cn.Open(); return (int)cmd.ExecuteScalar();
    }
    public static void CambiarEstado(int id, bool activo, int idUsuario)
    {
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Paciente_CambiarEstado", ("@IdPaciente", id), ("@Activo", activo), ("@IdUsuario", idUsuario));
        cn.Open(); cmd.ExecuteNonQuery();
    }
}

public static class LoteDatos
{
    static LoteProducto Leer(SqlDataReader dr) => new LoteProducto { IdLote = (int)dr["IdLote"], IdProducto = (int)dr["IdProducto"],
        NombreComercial = (string)dr["NombreComercial"], NroLote = (string)dr["NroLote"], FechaVencimiento = (DateTime)dr["FechaVencimiento"],
        Estado = (string)dr["Estado"], Activo = (bool)dr["Activo"] };
    public static List<LoteProducto> Listar()
    {
        var l = new List<LoteProducto>();
        using var cn = new SqlConnection(Conexion.Cadena); using var cmd = Conexion.Comando(cn, "sp_Lote_Listar");
        cn.Open(); using var dr = cmd.ExecuteReader(); while (dr.Read()) l.Add(Leer(dr)); return l;
    }
    public static LoteProducto Obtener(int id)
    {
        using var cn = new SqlConnection(Conexion.Cadena); using var cmd = Conexion.Comando(cn, "sp_Lote_Obtener", ("@IdLote", id));
        cn.Open(); using var dr = cmd.ExecuteReader(); return dr.Read() ? Leer(dr) : null;
    }
}

public static class SospechaDatos
{
    public static List<SospechaRAM> Listar(string estado = "")
    {
        var l = new List<SospechaRAM>();
        using var cn = new SqlConnection(Conexion.Cadena); using var cmd = Conexion.Comando(cn, "sp_Sospecha_Listar", ("@Estado", estado));
        cn.Open(); using var dr = cmd.ExecuteReader();
        while (dr.Read()) l.Add(new SospechaRAM { IdSospecha = (int)dr["IdSospecha"], CodigoCaso = (string)dr["CodigoCaso"], Paciente = (string)dr["Paciente"],
            Gravedad = dr["Gravedad"] as string, FechaHoraDeteccion = (DateTime)dr["FechaHoraDeteccion"], FechaLimite = (DateTime)dr["FechaLimite"],
            Estado = (string)dr["Estado"], MinutosRestantes = (int)dr["MinutosRestantes"] });
        return l;
    }
    public static string Registrar(int idAtencion, int idAdmin, string rol, string reaccion, DateTime inicio, string desc, int idPersonal)
    {
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Sospecha_Registrar", ("@IdAtencion", idAtencion), ("@IdAdministracion", idAdmin),
            ("@RolProducto", rol), ("@Reaccion", reaccion), ("@FechaInicio", inicio), ("@Descripcion", desc), ("@IdPersonal", idPersonal));
        cn.Open(); using var dr = cmd.ExecuteReader(); dr.Read(); return (string)dr["CodigoCaso"];
    }
    public static void Evaluar(int id, string gravedad, string causalidad, bool requiere, int idUsuario)
    {
        using var cn = new SqlConnection(Conexion.Cadena);
        using var cmd = Conexion.Comando(cn, "sp_Sospecha_Evaluar", ("@IdSospecha", id), ("@Gravedad", gravedad), ("@Causalidad", causalidad), ("@Requiere", requiere), ("@IdUsuario", idUsuario));
        cn.Open(); cmd.ExecuteNonQuery();
    }
}
