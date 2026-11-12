

using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SANNA.Presentacion.Contenedores
{
    public partial class FrmPersonalSalud : Form
    {
        private DataTable tabla = new DataTable();
        private int siguienteCodigo = 1;

        private TextBox txtDni = new TextBox();
        private TextBox txtNombres = new TextBox();
        private TextBox txtApellidos = new TextBox();
        private TextBox txtCMP = new TextBox();
        private TextBox txtTelefono = new TextBox();
        private TextBox txtBuscar = new TextBox();

        private ComboBox cboEspecialidad = new ComboBox();
        private ComboBox cboEstado = new ComboBox();

        private DataGridView dgvPersonal = new DataGridView();

        public FrmPersonalSalud()
        {
            InitializeComponent();
            ConstruirInterfaz();
            CrearTabla();
        }

        private void ConstruirInterfaz()
        {
            Controls.Clear();

            Text = "FrmPersonalSalud";
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            Label titulo = new Label()
            {
                Text = "Gestión de personal de salud",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkOliveGreen,
                Location = new Point(50, 25),
                AutoSize = true
            };

            GroupBox grupo = new GroupBox()
            {
                Text = "Datos del personal de salud",
                Font = new Font("Segoe UI", 9),
                Location = new Point(45, 65),
                Size = new Size(850, 190)
            };

            AgregarCampo(grupo, "DNI:", txtDni, 20, 30);
            AgregarCampo(grupo, "Nombres:", txtNombres, 290, 30);
            AgregarCampo(grupo, "Apellidos:", txtApellidos, 560, 30);

            AgregarCampo(grupo, "Especialidad:", cboEspecialidad, 20, 105);
            AgregarCampo(grupo, "CMP:", txtCMP, 290, 105);
            AgregarCampo(grupo, "Teléfono:", txtTelefono, 560, 105);

            cboEspecialidad.Items.AddRange(new object[]
            {
                "Medicina General",
                "Cardiología",
                "Pediatría",
                "Neurología",
                "Dermatología",
                "Enfermería",
                "Otra"
            });

            cboEstado.Items.AddRange(new object[]
            {
                "Activo",
                "Inactivo"
            });

            cboEstado.SelectedIndex = 0;

            Label lblEstado = new Label()
            {
                Text = "Estado:",
                Location = new Point(20, 165),
                AutoSize = true
            };

            grupo.Controls.Add(lblEstado);
            cboEstado.Location = new Point(90, 161);
            cboEstado.Size = new Size(150, 25);
            grupo.Controls.Add(cboEstado);

            Label lblBuscar = new Label()
            {
                Text = "Buscar personal:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkOliveGreen,
                Location = new Point(50, 275),
                AutoSize = true
            };

            txtBuscar.Location = new Point(50, 300);
            txtBuscar.Size = new Size(300, 25);

            Button btnBuscar = CrearBoton("Buscar", 370, 298);
            Button btnTodos = CrearBoton("Mostrar todos", 480, 298);

            btnBuscar.Click += (s, e) => BuscarPersonal();
            btnTodos.Click += (s, e) =>
            {
                tabla.DefaultView.RowFilter = "";
                txtBuscar.Clear();
            };

            Label lblTabla = new Label()
            {
                Text = "Tabla de personal de salud",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkOliveGreen,
                Location = new Point(50, 345),
                AutoSize = true
            };

            dgvPersonal.Location = new Point(50, 370);
            dgvPersonal.Size = new Size(850, 250);
            dgvPersonal.BackgroundColor = Color.LightGray;
            dgvPersonal.AllowUserToAddRows = false;
            dgvPersonal.ReadOnly = true;
            dgvPersonal.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPersonal.MultiSelect = false;
            dgvPersonal.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPersonal.CellClick += (s, e) => CargarSeleccion();

            Button btnNuevo = CrearBoton("NUEVO", 170, 650);
            Button btnGuardar = CrearBoton("GUARDAR", 330, 650);
            Button btnModificar = CrearBoton("MODIFICAR", 490, 650);
            Button btnEstado = CrearBoton("ACTIVAR / DESACTIVAR", 650, 650);

            btnNuevo.Click += (s, e) => LimpiarCampos();
            btnGuardar.Click += (s, e) => GuardarPersonal();
            btnModificar.Click += (s, e) => ModificarPersonal();
            btnEstado.Click += (s, e) => CambiarEstado();

            Controls.Add(titulo);
            Controls.Add(grupo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnTodos);
            Controls.Add(lblTabla);
            Controls.Add(dgvPersonal);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEstado);
        }

        private void AgregarCampo(
            GroupBox grupo, string texto, Control control,
            int x, int y)
        {
            Label etiqueta = new Label()
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            control.Location = new Point(x, y + 25);
            control.Size = new Size(240, 25);

            if (control is ComboBox combo)
                combo.DropDownStyle = ComboBoxStyle.DropDownList;

            grupo.Controls.Add(etiqueta);
            grupo.Controls.Add(control);
        }

        private Button CrearBoton(string texto, int x, int y)
        {
            return new Button()
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(145, 38),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
        }

        private void CrearTabla()
        {
            tabla.Columns.Add("Código", typeof(int));
            tabla.Columns.Add("DNI");
            tabla.Columns.Add("Nombres");
            tabla.Columns.Add("Apellidos");
            tabla.Columns.Add("Especialidad");
            tabla.Columns.Add("CMP");
            tabla.Columns.Add("Teléfono");
            tabla.Columns.Add("Estado");

            dgvPersonal.DataSource = tabla;
        }

        private void GuardarPersonal()
        {
            if (txtDni.Text.Trim() == "" ||
                txtNombres.Text.Trim() == "" ||
                txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Complete DNI, nombres y apellidos.");
                return;
            }

            tabla.Rows.Add(
                siguienteCodigo++,
                txtDni.Text.Trim(),
                txtNombres.Text.Trim(),
                txtApellidos.Text.Trim(),
                cboEspecialidad.Text,
                txtCMP.Text.Trim(),
                txtTelefono.Text.Trim(),
                cboEstado.Text
            );

            MessageBox.Show("Personal registrado correctamente.");
            LimpiarCampos();
        }

        private void CargarSeleccion()
        {
            if (dgvPersonal.CurrentRow == null ||
                dgvPersonal.CurrentRow.DataBoundItem is not DataRowView fila)
                return;

            txtDni.Text = fila["DNI"].ToString();
            txtNombres.Text = fila["Nombres"].ToString();
            txtApellidos.Text = fila["Apellidos"].ToString();
            cboEspecialidad.Text = fila["Especialidad"].ToString();
            txtCMP.Text = fila["CMP"].ToString();
            txtTelefono.Text = fila["Teléfono"].ToString();
            cboEstado.Text = fila["Estado"].ToString();
        }

        private void ModificarPersonal()
        {
            if (dgvPersonal.CurrentRow == null ||
                dgvPersonal.CurrentRow.DataBoundItem is not DataRowView fila)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            fila["DNI"] = txtDni.Text.Trim();
            fila["Nombres"] = txtNombres.Text.Trim();
            fila["Apellidos"] = txtApellidos.Text.Trim();
            fila["Especialidad"] = cboEspecialidad.Text;
            fila["CMP"] = txtCMP.Text.Trim();
            fila["Teléfono"] = txtTelefono.Text.Trim();
            fila["Estado"] = cboEstado.Text;

            MessageBox.Show("Registro modificado correctamente.");
            LimpiarCampos();
        }

        private void CambiarEstado()
        {
            if (dgvPersonal.CurrentRow == null ||
                dgvPersonal.CurrentRow.DataBoundItem is not DataRowView fila)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            fila["Estado"] = fila["Estado"].ToString() == "Activo"
                ? "Inactivo" : "Activo";

            cboEstado.Text = fila["Estado"].ToString();

            MessageBox.Show("Estado actualizado.");
        }

        private void BuscarPersonal()
        {
            string filtro = txtBuscar.Text.Trim().Replace("'", "''");

            tabla.DefaultView.RowFilter =
                $"Convert([DNI], 'System.String') LIKE '%{filtro}%' " +
                $"OR [Nombres] LIKE '%{filtro}%' " +
                $"OR [Apellidos] LIKE '%{filtro}%'";
        }

        private void LimpiarCampos()
        {
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCMP.Clear();
            txtTelefono.Clear();

            cboEspecialidad.SelectedIndex = -1;
            cboEstado.SelectedIndex = 0;

            dgvPersonal.ClearSelection();
        }
    }
}
