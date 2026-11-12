using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANNA.Entidades
{
    public class ProductoFarmaceutico
    {
        public int IdProducto { get; set; }

        public string NombreComercial { get; set; }

        public string PrincipioActivo { get; set; }

        public string FormaFarmaceutica { get; set; }

        public string Concentracion { get; set; }

        public int IdLaboratorio { get; set; }

        public string NombreLaboratorio { get; set; }

        public string RegistroSanitario { get; set; }

        public bool Activo { get; set; } = true;
    }

    public class LaboratorioItem
    {
        public int IdLaboratorio { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
