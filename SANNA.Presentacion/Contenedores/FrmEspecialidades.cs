using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SANNA.Negocio;
using SANNA.Entidades;


using System;
using System.Windows.Forms;
using SANNA.Negocio;
using SANNA.Entidades;

namespace SANNA.Presentacion.Contenedores
{
    public partial class FrmEspecialidades : Form
    {
        private readonly EspecialidadNegocio negocio = new();

        private int idSeleccionado = 0;
        private bool estadoSeleccionado = true;

        public FrmEspecialidades()
        {
            InitializeComponent();

            dgvEspecialidades.CellClick += dgvEspecialidades_CellClick;

            dgvEspecialidades.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.MultiSelect = false;
            dgvEspecialidades.ReadOnly = true;
            dgvEspecialidades.AllowUserToAddRows = false;

            try
            {
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las especialidades: "
                    + ex.Message,
                    "Error de conexión");
            }
        }

        // LISTAR ESPECIALIDADES
        private void CargarEspecialidades()
        {
            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = negocio.Listar();
            dgvEspecialidades.ClearSelection();
        }

        // LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            estadoSeleccionado = true;
            txtNombre.Clear();
            txtNombre.Focus();
            dgvEspecialidades.ClearSelection();
        }

        // BOTÓN NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // BOTÓN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.Registrar(txtNombre.Text);

                MessageBox.Show(
                    "Especialidad registrada correctamente.");

                CargarEspecialidades();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // BOTÓN MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.Modificar(
                    idSeleccionado,
                    txtNombre.Text);

                MessageBox.Show(
                    "Especialidad modificada correctamente.");

                CargarEspecialidades();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // BOTÓN ACTIVAR / DESACTIVAR
        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado <= 0)
                {
                    MessageBox.Show(
                        "Seleccione una especialidad.");
                    return;
                }

                negocio.CambiarEstado(
                    idSeleccionado,
                    !estadoSeleccionado);

                MessageBox.Show(
                    "Estado actualizado correctamente.");

                CargarEspecialidades();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // BUSCAR ESPECIALIDADES
        private void txtBuscar_TextChanged(
            object sender, EventArgs e)
        {
            try
            {
                dgvEspecialidades.DataSource =
                    negocio.Buscar(txtBuscar.Text);

                dgvEspecialidades.ClearSelection();
                idSeleccionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // SELECCIONAR UNA FILA DE LA TABLA
        private void dgvEspecialidades_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var fila = dgvEspecialidades.Rows[e.RowIndex];

            if (fila.DataBoundItem is Especialidad esp)
            {
                idSeleccionado = esp.IdEspecialidad;
                txtNombre.Text = esp.Nombre;
                estadoSeleccionado = esp.Activo;
            }
        }
    }
}
