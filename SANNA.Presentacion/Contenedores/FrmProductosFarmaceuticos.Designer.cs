namespace SANNA.Presentacion.Contenedores
{
    partial class FrmProductosFarmaceuticos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlBusqueda = new Panel();
            btnMostrarTodos = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            dgvProductos = new DataGridView();
            grpDatos = new GroupBox();
            btnCambiarEstado = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            cmbLaboratorio = new ComboBox();
            cmbFormaFarmaceutica = new ComboBox();
            txtConcentracion = new TextBox();
            txtRegistroSanitario = new TextBox();
            txtPrincipioActivo = new TextBox();
            txtNombreComercial = new TextBox();
            lblRegistro = new Label();
            lblLaboratorio = new Label();
            lblConcentracion = new Label();
            lblForma = new Label();
            lblPrincipio = new Label();
            lblNombre = new Label();
            label1 = new Label();
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.BackColor = Color.Transparent;
            pnlBusqueda.Controls.Add(btnMostrarTodos);
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblBuscar);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(0, 0);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(1137, 105);
            pnlBusqueda.TabIndex = 0;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMostrarTodos.Location = new Point(659, 55);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(137, 29);
            btnMostrarTodos.TabIndex = 3;
            btnMostrarTodos.Text = "Mostrar todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(659, 17);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(137, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBuscar.ForeColor = SystemColors.ControlDarkDark;
            txtBuscar.Location = new Point(264, 54);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(305, 30);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.DarkOliveGreen;
            lblBuscar.Location = new Point(264, 19);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(146, 23);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar producto:";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(116, 158);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(878, 480);
            dgvProductos.TabIndex = 1;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(btnCambiarEstado);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(cmbLaboratorio);
            grpDatos.Controls.Add(cmbFormaFarmaceutica);
            grpDatos.Controls.Add(txtConcentracion);
            grpDatos.Controls.Add(txtRegistroSanitario);
            grpDatos.Controls.Add(txtPrincipioActivo);
            grpDatos.Controls.Add(txtNombreComercial);
            grpDatos.Controls.Add(lblRegistro);
            grpDatos.Controls.Add(lblLaboratorio);
            grpDatos.Controls.Add(lblConcentracion);
            grpDatos.Controls.Add(lblForma);
            grpDatos.Controls.Add(lblPrincipio);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDatos.Location = new Point(166, 651);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(745, 267);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del producto farmacéutico";
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambiarEstado.Location = new Point(447, 229);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(110, 29);
            btnCambiarEstado.TabIndex = 14;
            btnCambiarEstado.Text = "Inhabilitar";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(310, 229);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 29);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(162, 229);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(104, 29);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(518, 73);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(207, 31);
            cmbLaboratorio.TabIndex = 11;
            // 
            // cmbFormaFarmaceutica
            // 
            cmbFormaFarmaceutica.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbFormaFarmaceutica.FormattingEnabled = true;
            cmbFormaFarmaceutica.Location = new Point(274, 75);
            cmbFormaFarmaceutica.Name = "cmbFormaFarmaceutica";
            cmbFormaFarmaceutica.Size = new Size(207, 31);
            cmbFormaFarmaceutica.TabIndex = 10;
            // 
            // txtConcentracion
            // 
            txtConcentracion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConcentracion.Location = new Point(274, 158);
            txtConcentracion.Name = "txtConcentracion";
            txtConcentracion.Size = new Size(207, 30);
            txtConcentracion.TabIndex = 9;
            // 
            // txtRegistroSanitario
            // 
            txtRegistroSanitario.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRegistroSanitario.Location = new Point(519, 158);
            txtRegistroSanitario.Name = "txtRegistroSanitario";
            txtRegistroSanitario.Size = new Size(207, 30);
            txtRegistroSanitario.TabIndex = 8;
            // 
            // txtPrincipioActivo
            // 
            txtPrincipioActivo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrincipioActivo.Location = new Point(17, 158);
            txtPrincipioActivo.Name = "txtPrincipioActivo";
            txtPrincipioActivo.Size = new Size(216, 30);
            txtPrincipioActivo.TabIndex = 7;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNombreComercial.Location = new Point(17, 75);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(216, 30);
            txtNombreComercial.TabIndex = 6;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistro.Location = new Point(518, 130);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(151, 23);
            lblRegistro.TabIndex = 5;
            lblRegistro.Text = "Registro sanitario";
            // 
            // lblLaboratorio
            // 
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLaboratorio.Location = new Point(518, 43);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(104, 23);
            lblLaboratorio.TabIndex = 4;
            lblLaboratorio.Text = "Laboratorio";
            // 
            // lblConcentracion
            // 
            lblConcentracion.AutoSize = true;
            lblConcentracion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConcentracion.Location = new Point(280, 126);
            lblConcentracion.Name = "lblConcentracion";
            lblConcentracion.Size = new Size(124, 23);
            lblConcentracion.TabIndex = 3;
            lblConcentracion.Text = "Concentración";
            // 
            // lblForma
            // 
            lblForma.AutoSize = true;
            lblForma.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblForma.Location = new Point(274, 43);
            lblForma.Name = "lblForma";
            lblForma.Size = new Size(170, 23);
            lblForma.TabIndex = 2;
            lblForma.Text = "Forma farmacéutica";
            // 
            // lblPrincipio
            // 
            lblPrincipio.AutoSize = true;
            lblPrincipio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrincipio.Location = new Point(17, 124);
            lblPrincipio.Name = "lblPrincipio";
            lblPrincipio.Size = new Size(134, 23);
            lblPrincipio.TabIndex = 1;
            lblPrincipio.Text = "Principio activo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(17, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(158, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre comercial";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(114, 128);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 3;
            label1.Text = "Tabla de fármacos";
            // 
            // FrmProductosFarmaceuticos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1137, 932);
            Controls.Add(label1);
            Controls.Add(grpDatos);
            Controls.Add(dgvProductos);
            Controls.Add(pnlBusqueda);
            Name = "FrmProductosFarmaceuticos";
            Text = "FrmProductosFarmaceuticos";
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBusqueda;
        private Button btnMostrarTodos;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView dgvProductos;
        private GroupBox grpDatos;
        private ComboBox cmbLaboratorio;
        private ComboBox cmbFormaFarmaceutica;
        private TextBox txtConcentracion;
        private TextBox txtRegistroSanitario;
        private TextBox txtPrincipioActivo;
        private TextBox txtNombreComercial;
        private Label lblRegistro;
        private Label lblLaboratorio;
        private Label lblConcentracion;
        private Label lblForma;
        private Label lblPrincipio;
        private Label lblNombre;
        private Button btnCambiarEstado;
        private Button btnGuardar;
        private Button btnNuevo;
        private Label label1;
    }
}