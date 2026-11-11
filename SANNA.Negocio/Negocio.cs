using System.Security.Cryptography;
using System.Text;
using SANNA.Datos;
using SANNA.Entidades;
namespace SANNA.Negocio;

public static class Sesion
{
    public static Usuario Actual { get; set; }
    static readonly Dictionary<string, string[]> Permisos = new()
    {
        ["Administrador"] = new[] { "pacientes", "lotes", "auditoria" },
        ["Admisión"]      = new[] { "pacientes", "citas", "ingreso" },
        ["Médico"]        = new[] { "citas", "atencion", "sospecha", "consultas" },
        ["Enfermero"]     = new[] { "atencion", "administracion", "sospecha" },
        ["Químico"]       = new[] { "lotes", "administracion", "sospecha", "notificacion", "seguimiento", "consultas" },
        ["Comité"]        = new[] { "evaluacion", "notificacion", "seguimiento", "consultas" },
    };
    public static bool Puede(string modulo) => Actual != null && Permisos.TryGetValue(Actual.Rol, out var p) && p.Contains(modulo);
}

public static class SeguridadNegocio
{
    // Debe coincidir con HASHBYTES('SHA2_256', sal + CAST(clave AS VARBINARY)) del script (UTF-16LE).
    public static byte[] Hash(byte[] sal, string clave) => SHA256.HashData(sal.Concat(Encoding.Unicode.GetBytes(clave)).ToArray());

    public static Usuario Autenticar(string usuario, string clave)
    {
        var u = UsuarioDatos.Obtener(usuario?.Trim());
        if (u == null || !u.Activo) return null;
        return CryptographicOperations.FixedTimeEquals(u.ClaveHash, Hash(u.ClaveSal, clave)) ? u : null;
    }
}

public interface IParametros { int PlazoGraveHoras { get; } int PlazoLeveModeradaHoras { get; } }
public class ParametrosPorDefecto : IParametros { public int PlazoGraveHoras => 24; public int PlazoLeveModeradaHoras => 72; }

public static class PlazoNegocio
{
    public static DateTime CalcularFechaLimite(DateTime fechaDeteccion, string gravedad, IParametros p)
        => fechaDeteccion.AddHours(gravedad == "Grave" ? p.PlazoGraveHoras : p.PlazoLeveModeradaHoras);

    public static string TextoRestante(int minutos)
        => minutos < 0 ? $"VENCIDO hace {-minutos / 60}h {-minutos % 60}m" : $"Quedan {minutos / 60}h {minutos % 60}m";
}

public static class PacienteNegocio
{
    public static void Guardar(Paciente p)
    {
        if (string.IsNullOrWhiteSpace(p.NroDocumento) || string.IsNullOrWhiteSpace(p.Apellidos) || string.IsNullOrWhiteSpace(p.Nombres))
            throw new InvalidOperationException("Documento, apellidos y nombres son obligatorios.");
        if (p.FechaNacimiento.Date > DateTime.Today) throw new InvalidOperationException("La fecha de nacimiento no puede ser futura.");
        if (p.Sexo != "M" && p.Sexo != "F") throw new InvalidOperationException("Seleccione el sexo.");
        p.IdPaciente = PacienteDatos.Guardar(p, Sesion.Actual.IdUsuario);
    }
}

public static class LoteNegocio
{
    /// Regla RF13: bloquear lotes inmovilizados o vencidos antes de administrar.
    public static void ValidarParaAdministrar(LoteProducto l)
    {
        if (l == null) throw new InvalidOperationException("Lote no encontrado.");
        if (l.Estado != "Vigente") throw new InvalidOperationException($"ALERTA: el lote {l.NroLote} está {l.Estado.ToLower()}. Administración bloqueada.");
        if (l.FechaVencimiento.Date < DateTime.Today) throw new InvalidOperationException($"ALERTA: el lote {l.NroLote} está vencido.");
    }
}
