
using SANNA.Datos;
using SANNA.Entidades;
using System;
using System.Collections.Generic;

namespace SANNA.Negocio
{
    public static class ProductoFarmaceuticoNegocio
    {
        // 1. LISTAR LABORATORIOS ACTIVOS
        public static List<LaboratorioItem> ListarLaboratoriosActivos()
        {
            return ProductoFarmaceuticoDatos.ListarLaboratoriosActivos();
        }


        // 2. LISTAR Y BUSCAR PRODUCTOS
        public static List<ProductoFarmaceutico> Listar(string filtro = "")
        {
            return ProductoFarmaceuticoDatos.Listar(
                (filtro ?? "").Trim()
            );
        }


        // 3. REGISTRAR Y ACTUALIZAR PRODUCTOS
        public static int Guardar(ProductoFarmaceutico p)
        {
            if (p == null)
                throw new InvalidOperationException("Producto no válido.");

            // Limpiar espacios
            p.NombreComercial = (p.NombreComercial ?? "").Trim();
            p.PrincipioActivo = (p.PrincipioActivo ?? "").Trim();
            p.RegistroSanitario = (p.RegistroSanitario ?? "").Trim();

            p.FormaFarmaceutica =
                string.IsNullOrWhiteSpace(p.FormaFarmaceutica)
                    ? null
                    : p.FormaFarmaceutica.Trim();

            p.Concentracion =
                string.IsNullOrWhiteSpace(p.Concentracion)
                    ? null
                    : p.Concentracion.Trim();


            if (string.IsNullOrWhiteSpace(p.NombreComercial))
                throw new InvalidOperationException(
                    "Ingrese el nombre comercial del producto.");

            if (string.IsNullOrWhiteSpace(p.PrincipioActivo))
                throw new InvalidOperationException(
                    "Ingrese el principio activo.");

            if (string.IsNullOrWhiteSpace(p.RegistroSanitario))
                throw new InvalidOperationException(
                    "Ingrese el registro sanitario.");

            if (p.IdLaboratorio <= 0)
                throw new InvalidOperationException(
                    "Seleccione un laboratorio.");


            if (p.NombreComercial.Length > 100)
                throw new InvalidOperationException(
                    "El nombre comercial no debe superar 100 caracteres.");

            if (p.PrincipioActivo.Length > 100)
                throw new InvalidOperationException(
                    "El principio activo no debe superar 100 caracteres.");

            if (p.FormaFarmaceutica?.Length > 50)
                throw new InvalidOperationException(
                    "La forma farmacéutica no debe superar 50 caracteres.");

            if (p.Concentracion?.Length > 30)
                throw new InvalidOperationException(
                    "La concentración no debe superar 30 caracteres.");

            if (p.RegistroSanitario.Length > 30)
                throw new InvalidOperationException(
                    "El registro sanitario no debe superar 30 caracteres.");

            if (Sesion.Actual == null)
                throw new InvalidOperationException(
                    "Debe iniciar sesión para realizar esta operación.");

            return ProductoFarmaceuticoDatos.Guardar(
                p,
                Sesion.Actual.IdUsuario
            );
        }

        // 4. ACTIVAR E INHABILITAR PRODUCTOS
        public static void CambiarEstado(int idProducto, bool activo)
        {
            if (idProducto <= 0)
                throw new InvalidOperationException(
                    "Seleccione un producto válido.");

            if (Sesion.Actual == null)
                throw new InvalidOperationException(
                    "Debe iniciar sesión para realizar esta operación.");

            ProductoFarmaceuticoDatos.CambiarEstado(
                idProducto,
                activo,
                Sesion.Actual.IdUsuario
            );
        }
    }
}
