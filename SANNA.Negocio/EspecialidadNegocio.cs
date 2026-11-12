using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.Linq;
using SANNA.Datos;
using SANNA.Entidades;

namespace SANNA.Negocio
{
    public class EspecialidadNegocio
    {
        private readonly EspecialidadDatos datos =
            new EspecialidadDatos();

        // LISTAR
        public List<Especialidad> Listar()
        {
            return datos.Listar();
        }

        // BUSCAR
        public List<Especialidad> Buscar(string texto)
        {
            return datos.Listar()
                .Where(e => e.Nombre.Contains(
                    texto ?? "",
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // REGISTRAR
        public void Registrar(string nombre)
        {
            nombre = ValidarNombre(nombre);

            if (datos.Listar().Any(e =>
                string.Equals(e.Nombre, nombre,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception(
                    "La especialidad ya está registrada.");
            }

            datos.Registrar(new Especialidad
            {
                Nombre = nombre,
                Activo = true
            });
        }

        // MODIFICAR
        public void Modificar(int id, string nombre)
        {
            nombre = ValidarNombre(nombre);

            if (id <= 0)
                throw new Exception(
                    "Seleccione una especialidad.");

            if (datos.Listar().Any(e =>
                e.IdEspecialidad != id &&
                string.Equals(e.Nombre, nombre,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception(
                    "Ya existe otra especialidad con ese nombre.");
            }

            datos.Modificar(new Especialidad
            {
                IdEspecialidad = id,
                Nombre = nombre
            });
        }

        // ACTIVAR O DESACTIVAR
        public void CambiarEstado(int id, bool activo)
        {
            if (id <= 0)
                throw new Exception(
                    "Seleccione una especialidad.");

            datos.CambiarEstado(id, activo);
        }

        // VALIDAR NOMBRE
        private string ValidarNombre(string nombre)
        {
            nombre = (nombre ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception(
                    "Ingrese el nombre de la especialidad.");

            if (nombre.Length > 60)
                throw new Exception(
                    "El nombre no puede superar 60 caracteres.");

            return nombre;
        }
    }
}
