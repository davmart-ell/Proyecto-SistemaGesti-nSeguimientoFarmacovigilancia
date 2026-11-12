using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SANNA.Entidades;

namespace SANNA.Datos
{
    public class EspecialidadDatos
    {
        // LISTAR ESPECIALIDADES
        public List<Especialidad> Listar()
        {
            var lista = new List<Especialidad>();

            using var cn = new SqlConnection(Conexion.Cadena);
            cn.Open();

            const string sql = """
                SELECT IdEspecialidad, Nombre, Activo
                FROM Especialidad
                ORDER BY Nombre
                """;

            using var cmd = new SqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Especialidad
                {
                    IdEspecialidad = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    Activo = dr.GetBoolean(2)
                });
            }

            return lista;
        }

        // REGISTRAR ESPECIALIDAD
        public void Registrar(Especialidad especialidad)
        {
            using var cn = new SqlConnection(Conexion.Cadena);
            cn.Open();

            const string sql = """
                INSERT INTO Especialidad (Nombre, Activo)
                VALUES (@Nombre, @Activo)
                """;

            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.Add("@Nombre",
                System.Data.SqlDbType.VarChar, 60)
                .Value = especialidad.Nombre;

            cmd.Parameters.Add("@Activo",
                System.Data.SqlDbType.Bit)
                .Value = especialidad.Activo;

            cmd.ExecuteNonQuery();
        }

        // MODIFICAR ESPECIALIDAD
        public void Modificar(Especialidad especialidad)
        {
            using var cn = new SqlConnection(Conexion.Cadena);
            cn.Open();

            const string sql = """
                UPDATE Especialidad
                SET Nombre = @Nombre
                WHERE IdEspecialidad = @Id
                """;

            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.Add("@Nombre",
                System.Data.SqlDbType.VarChar, 60)
                .Value = especialidad.Nombre;

            cmd.Parameters.Add("@Id",
                System.Data.SqlDbType.Int)
                .Value = especialidad.IdEspecialidad;

            cmd.ExecuteNonQuery();
        }

        // ACTIVAR O DESACTIVAR
        public void CambiarEstado(int id, bool activo)
        {
            using var cn = new SqlConnection(Conexion.Cadena);
            cn.Open();

            const string sql = """
                UPDATE Especialidad
                SET Activo = @Activo
                WHERE IdEspecialidad = @Id
                """;

            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.Add("@Activo",
                System.Data.SqlDbType.Bit)
                .Value = activo;

            cmd.Parameters.Add("@Id",
                System.Data.SqlDbType.Int)
                .Value = id;

            cmd.ExecuteNonQuery();
        }
    }
}
