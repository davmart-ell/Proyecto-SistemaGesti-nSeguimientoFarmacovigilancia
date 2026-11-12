
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SANNA.Entidades;
using SANNA.Negocio;

namespace SANNA.Presentacion.Contenedores
{
    public partial class FrmProductosFarmaceuticos : Form
    {
        private List<ProductoFarmaceutico> productos = new();
        private ProductoFarmaceutico actual = new();
        private bool cargando = false;

        public FrmProductosFarmaceuticos()
        {
            InitializeComponent();

            ConfigurarControles();
            RegistrarEventos();

            Load += FrmProductosFarmaceuticos_Load;
        }

        private void ConfigurarControles()
        {
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            cmbFormaFarmaceutica.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbLaboratorio.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbFormaFarmaceutica.Items.Clear();

            cmbFormaFarmaceutica.Items.AddRange(new object[]
            {
                "(No especificada)",
                "Tableta",
                "Cápsula",
                "Solución oral",
                "Suspensión oral",
                "Solución inyectable",
                "Jarabe",
                "Crema",
                "Ungüento",
                "Gotas",
                "Polvo",
                "Otra"
            });

            cmbFormaFarmaceutica.SelectedIndex = 0;

            btnCambiarEstado.Enabled = false;
        }

        private void RegistrarEventos()
        {
            btnBuscar.Click += (_, _) => CargarProductos();

            btnMostrarTodos.Click += (_, _) =>
            {
                txtBuscar.Clear();
                CargarProductos();
            };

            txtBuscar.KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CargarProductos();
                    e.SuppressKeyPress = true;
                }
            };

            btnNuevo.Click += (_, _) => Limpiar();

            btnGuardar.Click += (_, _) => Guardar();

            btnCambiarEstado.Click += (_, _) => CambiarEstado();

            dgvProductos.SelectionChanged +=
                (_, _) => SeleccionarProducto();
        }

        private void FrmProductosFarmaceuticos_Load(
            object sender, EventArgs e)
        {
            CargarLaboratorios();
            CargarProductos();
        }

        private void CargarLaboratorios()
        {
            try
            {
                cmbLaboratorio.DataSource =
                    ProductoFarmaceuticoNegocio.ListarLaboratoriosActivos();

                cmbLaboratorio.DisplayMember = "Nombre";
                cmbLaboratorio.ValueMember = "IdLaboratorio";

                cmbLaboratorio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar laboratorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarProductos()
        {
            try
            {
                cargando = true;

                productos = ProductoFarmaceuticoNegocio.Listar(
                    txtBuscar.Text.Trim()
                );

                dgvProductos.DataSource = null;

                dgvProductos.DataSource = productos.Select(p => new
                {
                    p.IdProducto,
                    p.NombreComercial,
                    p.PrincipioActivo,
                    p.FormaFarmaceutica,
                    p.Concentracion,
                    p.NombreLaboratorio,
                    p.RegistroSanitario,
                    Estado = p.Activo ? "Activo" : "Inactivo"

                }).ToList();

                if (dgvProductos.Columns.Count > 0)
                {
                    dgvProductos.Columns["IdProducto"].Visible = false;

                    dgvProductos.Columns["NombreComercial"].HeaderText =
                        "Nombre comercial";

                    dgvProductos.Columns["PrincipioActivo"].HeaderText =
                        "Principio activo";

                    dgvProductos.Columns["FormaFarmaceutica"].HeaderText =
                        "Forma farmacéutica";

                    dgvProductos.Columns["Concentracion"].HeaderText =
                        "Concentración";

                    dgvProductos.Columns["NombreLaboratorio"].HeaderText =
                        "Laboratorio";

                    dgvProductos.Columns["RegistroSanitario"].HeaderText =
                        "Registro sanitario";

                    dgvProductos.Columns["Estado"].HeaderText =
                        "Estado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al consultar productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            finally
            {
                cargando = false;
            }

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.CurrentCell =
                    dgvProductos.Rows[0].Cells["NombreComercial"];

                dgvProductos.Rows[0].Selected = true;

                SeleccionarProducto();
            }
            else
            {
                Limpiar();
            }
        }

        private void SeleccionarProducto()
        {
            if (cargando || dgvProductos.CurrentRow == null)
                return;

            if (dgvProductos.CurrentRow.Cells["IdProducto"].Value == null)
                return;

            int id = Convert.ToInt32(
                dgvProductos.CurrentRow.Cells["IdProducto"].Value
            );

            var p = productos.FirstOrDefault(
                x => x.IdProducto == id
            );

            if (p == null)
                return;

            actual = p;

            txtNombreComercial.Text = p.NombreComercial;
            txtPrincipioActivo.Text = p.PrincipioActivo;
            txtConcentracion.Text = p.Concentracion;
            txtRegistroSanitario.Text = p.RegistroSanitario;

            cmbFormaFarmaceutica.SelectedItem =
                p.FormaFarmaceutica ?? "(No especificada)";

            cmbLaboratorio.SelectedValue = p.IdLaboratorio;

            btnCambiarEstado.Text =
                p.Activo ? "Inhabilitar" : "Activar";

            btnCambiarEstado.Enabled = true;
        }


        // ==========================================
        // NUEVO PRODUCTO
        // ==========================================

        private void Limpiar()
        {
            actual = new ProductoFarmaceutico();

            txtNombreComercial.Clear();
            txtPrincipioActivo.Clear();
            txtConcentracion.Clear();
            txtRegistroSanitario.Clear();

            cmbFormaFarmaceutica.SelectedIndex = 0;
            cmbLaboratorio.SelectedIndex = -1;

            btnCambiarEstado.Text = "Inhabilitar";
            btnCambiarEstado.Enabled = false;

            dgvProductos.ClearSelection();

            txtNombreComercial.Focus();
        }

        private void Guardar()
        {
            try
            {
                var p = new ProductoFarmaceutico
                {
                    IdProducto = actual.IdProducto,

                    NombreComercial = txtNombreComercial.Text.Trim(),

                    PrincipioActivo = txtPrincipioActivo.Text.Trim(),

                    FormaFarmaceutica =
                        cmbFormaFarmaceutica.SelectedIndex > 0
                            ? cmbFormaFarmaceutica.Text
                            : null,

                    Concentracion = txtConcentracion.Text.Trim(),

                    IdLaboratorio =
                        cmbLaboratorio.SelectedValue == null
                            ? 0
                            : Convert.ToInt32(
                                cmbLaboratorio.SelectedValue
                            ),

                    RegistroSanitario = txtRegistroSanitario.Text.Trim(),

                    Activo = actual.Activo
                };

                int id = ProductoFarmaceuticoNegocio.Guardar(p);

                MessageBox.Show(
                    "Producto farmacéutico guardado correctamente.\nID: " + id,
                    "SANNA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtBuscar.Clear();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void CambiarEstado()
        {
            if (actual.IdProducto == 0)
                return;

            string accion = actual.Activo
                ? "inhabilitar"
                : "activar";

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea {accion} el producto {actual.NombreComercial}?",
                "Confirmar operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                ProductoFarmaceuticoNegocio.CambiarEstado(
                    actual.IdProducto,
                    !actual.Activo
                );

                MessageBox.Show(
                    "Estado actualizado correctamente.",
                    "SANNA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
