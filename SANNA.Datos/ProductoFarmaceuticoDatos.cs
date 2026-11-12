
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SANNA.Entidades;

namespace SANNA.Datos
{
    public static class ProductoFarmaceuticoDatos
    {
        // 1. LISTAR LABORATORIOS ACTIVOS
        public static List<LaboratorioItem> ListarLaboratoriosActivos()
        {
            var lista = new List<LaboratorioItem>();

            using var cn = new SqlConnection(Conexion.Cadena);

            using var cmd = Conexion.Comando(
                cn,
                "sp_Laboratorio_ListarActivos"
            );

            cn.Open();

            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new LaboratorioItem
                {
                    IdLaboratorio = Convert.ToInt32(dr["IdLaboratorio"]),
                    Nombre = dr["Nombre"].ToString()
                });
            }

            return lista;
        }

        // 2. LISTAR Y BUSCAR PRODUCTOS
        public static List<ProductoFarmaceutico> Listar(string filtro = "")
        {
            var lista = new List<ProductoFarmaceutico>();

            using var cn = new SqlConnection(Conexion.Cadena);

            using var cmd = Conexion.Comando(
                cn,
                "sp_ProductoFarmaceutico_Listar",
                ("@Filtro", filtro ?? "")
            );

            cn.Open();

            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new ProductoFarmaceutico
                {
                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    NombreComercial = dr["NombreComercial"].ToString(),
                    PrincipioActivo = dr["PrincipioActivo"].ToString(),
                    FormaFarmaceutica = dr["FormaFarmaceutica"] == DBNull.Value
                        ? null : dr["FormaFarmaceutica"].ToString(),
                    Concentracion = dr["Concentracion"] == DBNull.Value
                        ? null : dr["Concentracion"].ToString(),
                    IdLaboratorio = Convert.ToInt32(dr["IdLaboratorio"]),
                    NombreLaboratorio = dr["NombreLaboratorio"].ToString(),
                    RegistroSanitario = dr["RegistroSanitario"].ToString(),
                    Activo = Convert.ToBoolean(dr["Activo"])
                });
            }

            return lista;
        }

        // 3. REGISTRAR Y ACTUALIZAR PRODUCTOS
        public static int Guardar(ProductoFarmaceutico p, int idUsuario)
        {
            using var cn = new SqlConnection(Conexion.Cadena);

            using var cmd = Conexion.Comando(
                cn,
                "sp_ProductoFarmaceutico_Guardar",
                ("@IdProducto", p.IdProducto),
                ("@NombreComercial", p.NombreComercial),
                ("@PrincipioActivo", p.PrincipioActivo),
                ("@FormaFarmaceutica", p.FormaFarmaceutica),
                ("@Concentracion", p.Concentracion),
                ("@IdLaboratorio", p.IdLaboratorio),
                ("@RegistroSanitario", p.RegistroSanitario),
                ("@IdUsuario", idUsuario)
            );

            cn.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // 4. ACTIVAR E INHABILITAR PRODUCTOS
        public static void CambiarEstado(int id, bool activo, int idUsuario)
        {
            using var cn = new SqlConnection(Conexion.Cadena);

            using var cmd = Conexion.Comando(
                cn,
                "sp_ProductoFarmaceutico_CambiarEstado",
                ("@IdProducto", id),
                ("@Activo", activo),
                ("@IdUsuario", idUsuario)
            );

            cn.Open();

            cmd.ExecuteNonQuery();
        }
    }
}
