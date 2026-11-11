using SANNA.Datos;
using SANNA.Negocio;
namespace SANNA.Presentacion;

/// Consulta de lotes (CUS06). Completar con alta/edición siguiendo el patrón de FrmPacientes.
public class FrmLotes : Form
{
    public FrmLotes()
    {
        Text = "Lotes de productos"; Width = 800; Height = 450;
        var g = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        Controls.Add(g);
        Load += (_, _) => g.DataSource = LoteDatos.Listar().Select(l => new { Producto = l.NombreComercial, Lote = l.NroLote,
            Vence = l.FechaVencimiento.ToShortDateString(), l.Estado }).ToList();
    }
}
