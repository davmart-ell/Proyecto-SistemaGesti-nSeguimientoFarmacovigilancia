using SANNA.Datos;
using SANNA.Entidades;
using SANNA.Negocio;
namespace SANNA.Presentacion;

/// Mantenedor CRUD de pacientes (CUS02). Copie este patrón para personal, especialidades, productos y usuarios.
public class FrmPacientes : Form
{
    readonly DataGridView grid = new() { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false, RowHeadersVisible = false };
    readonly TextBox txtBuscar = new() { Width = 220 };
    readonly TextBox txtDoc = new() { Width = 130 }, txtApe = new() { Width = 180 }, txtNom = new() { Width = 180 }, txtTel = new() { Width = 130 };
    readonly DateTimePicker dtpNac = new() { Width = 130, Format = DateTimePickerFormat.Short };
    readonly ComboBox cmbSexo = new() { Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
    Paciente actual = new();

    public FrmPacientes()
    {
        Text = "Mantenedor de pacientes"; Width = 900; Height = 600;
        cmbSexo.Items.AddRange(new object[] { "M", "F" });
        var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40, Padding = new Padding(6) };
        var bBuscar = new Button { Text = "Buscar" }; bBuscar.Click += (_, _) => Cargar();
        top.Controls.AddRange(new Control[] { new Label { Text = "Buscar:", AutoSize = true, Padding = new Padding(0, 6, 0, 0) }, txtBuscar, bBuscar });

        var form = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 130, Padding = new Padding(6), WrapContents = true };
        void Campo(string t, Control c) { form.Controls.Add(new Label { Text = t, AutoSize = true, Padding = new Padding(0, 6, 0, 0) }); form.Controls.Add(c); }
        Campo("Documento", txtDoc); Campo("Apellidos", txtApe); Campo("Nombres", txtNom);
        Campo("Nacimiento", dtpNac); Campo("Sexo", cmbSexo); Campo("Teléfono", txtTel);
        var bNuevo = new Button { Text = "Nuevo" }; var bGuardar = new Button { Text = "Guardar" }; var bEstado = new Button { Text = "Activar/Desactivar", Width = 130 };
        bNuevo.Click += (_, _) => Limpiar(); bGuardar.Click += (_, _) => Guardar(); bEstado.Click += (_, _) => CambiarEstado();
        form.Controls.AddRange(new Control[] { bNuevo, bGuardar, bEstado });

        grid.SelectionChanged += (_, _) => Seleccionar();
        Controls.AddRange(new Control[] { grid, form, top });
        Load += (_, _) => Cargar();
    }

    void Cargar()
    {
        try
        {
            grid.DataSource = PacienteDatos.Listar(txtBuscar.Text).Select(p => new { p.IdPaciente, Documento = p.NroDocumento, Paciente = p.NombreCompleto,
                Nacimiento = p.FechaNacimiento.ToShortDateString(), p.Sexo, Teléfono = p.Telefono, Estado = p.Activo ? "Activo" : "Inactivo" }).ToList();
            if (grid.Columns.Count > 0) grid.Columns["IdPaciente"].Visible = false;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    void Seleccionar()
    {
        if (grid.CurrentRow == null) return;
        int id = (int)grid.CurrentRow.Cells["IdPaciente"].Value;
        var p = PacienteDatos.Listar(grid.CurrentRow.Cells["Documento"].Value.ToString()).FirstOrDefault(x => x.IdPaciente == id);
        if (p == null) return;
        actual = p; txtDoc.Text = p.NroDocumento; txtApe.Text = p.Apellidos; txtNom.Text = p.Nombres;
        dtpNac.Value = p.FechaNacimiento; cmbSexo.Text = p.Sexo; txtTel.Text = p.Telefono;
    }

    void Limpiar() { actual = new Paciente(); txtDoc.Clear(); txtApe.Clear(); txtNom.Clear(); txtTel.Clear(); cmbSexo.SelectedIndex = -1; dtpNac.Value = DateTime.Today.AddYears(-30); }

    void Guardar()
    {
        try
        {
            actual.NroDocumento = txtDoc.Text.Trim(); actual.Apellidos = txtApe.Text.Trim(); actual.Nombres = txtNom.Text.Trim();
            actual.FechaNacimiento = dtpNac.Value.Date; actual.Sexo = cmbSexo.Text; actual.Telefono = txtTel.Text.Trim();
            PacienteNegocio.Guardar(actual); MessageBox.Show("Paciente guardado."); Cargar();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }

    void CambiarEstado()
    {
        if (actual.IdPaciente == 0) return;
        PacienteDatos.CambiarEstado(actual.IdPaciente, !actual.Activo, Sesion.Actual.IdUsuario); Cargar();
    }
}
