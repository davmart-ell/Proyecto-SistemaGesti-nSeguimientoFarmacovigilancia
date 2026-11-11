namespace SANNA.Entidades;

public class Paciente
{
    public int IdPaciente { get; set; }
    public string NroDocumento { get; set; }
    public string Apellidos { get; set; }
    public string Nombres { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; } = true;
    public string NombreCompleto => $"{Apellidos}, {Nombres}";
}

public class Usuario
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public byte[] ClaveHash { get; set; }
    public byte[] ClaveSal { get; set; }
    public string Rol { get; set; }
    public bool Activo { get; set; }
}

public class LoteProducto
{
    public int IdLote { get; set; }
    public int IdProducto { get; set; }
    public string NombreComercial { get; set; }
    public string NroLote { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string Estado { get; set; }   // Vigente | Inmovilizado | Vencido
    public bool Activo { get; set; }
    public override string ToString() => $"{NombreComercial} · lote {NroLote}";
}

public class SospechaRAM
{
    public int IdSospecha { get; set; }
    public string CodigoCaso { get; set; }
    public string Paciente { get; set; }
    public string Gravedad { get; set; }
    public DateTime FechaHoraDeteccion { get; set; }
    public DateTime FechaLimite { get; set; }
    public string Estado { get; set; }
    public int MinutosRestantes { get; set; }
}
