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
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Controls.Add(btnMostrarTodos);
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblBuscar);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(0, 0);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(942, 110);
            pnlBusqueda.TabIndex = 0;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Location = new Point(544, 67);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(137, 29);
            btnMostrarTodos.TabIndex = 3;
            btnMostrarTodos.Text = "Mostrar todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(565, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(304, 45);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(125, 27);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(166, 48);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(120, 20);
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
            dgvProductos.Location = new Point(31, 123);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(878, 233);
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
            grpDatos.Location = new Point(93, 369);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(745, 275);
            grpDatos.TabIndex = 2;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del producto farmacéutico";
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Location = new Point(447, 229);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(94, 29);
            btnCambiarEstado.TabIndex = 14;
            btnCambiarEstado.Text = "Inhabilitar";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(310, 229);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(162, 229);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(463, 73);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(151, 28);
            cmbLaboratorio.TabIndex = 11;
            // 
            // cmbFormaFarmaceutica
            // 
            cmbFormaFarmaceutica.FormattingEnabled = true;
            cmbFormaFarmaceutica.Location = new Point(279, 75);
            cmbFormaFarmaceutica.Name = "cmbFormaFarmaceutica";
            cmbFormaFarmaceutica.Size = new Size(151, 28);
            cmbFormaFarmaceutica.TabIndex = 10;
            // 
            // txtConcentracion
            // 
            txtConcentracion.Location = new Point(295, 158);
            txtConcentracion.Name = "txtConcentracion";
            txtConcentracion.Size = new Size(125, 27);
            txtConcentracion.TabIndex = 9;
            // 
            // txtRegistroSanitario
            // 
            txtRegistroSanitario.Location = new Point(463, 158);
            txtRegistroSanitario.Name = "txtRegistroSanitario";
            txtRegistroSanitario.Size = new Size(125, 27);
            txtRegistroSanitario.TabIndex = 8;
            // 
            // txtPrincipioActivo
            // 
            txtPrincipioActivo.Location = new Point(103, 158);
            txtPrincipioActivo.Name = "txtPrincipioActivo";
            txtPrincipioActivo.Size = new Size(125, 27);
            txtPrincipioActivo.TabIndex = 7;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(103, 75);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(125, 27);
            txtNombreComercial.TabIndex = 6;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Location = new Point(463, 134);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(125, 20);
            lblRegistro.TabIndex = 5;
            lblRegistro.Text = "Registro sanitario";
            // 
            // lblLaboratorio
            // 
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Location = new Point(463, 43);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(87, 20);
            lblLaboratorio.TabIndex = 4;
            lblLaboratorio.Text = "Laboratorio";
            // 
            // lblConcentracion
            // 
            lblConcentracion.AutoSize = true;
            lblConcentracion.Location = new Point(269, 126);
            lblConcentracion.Name = "lblConcentracion";
            lblConcentracion.Size = new Size(104, 20);
            lblConcentracion.TabIndex = 3;
            lblConcentracion.Text = "Concentración";
            // 
            // lblForma
            // 
            lblForma.AutoSize = true;
            lblForma.Location = new Point(279, 43);
            lblForma.Name = "lblForma";
            lblForma.Size = new Size(141, 20);
            lblForma.TabIndex = 2;
            lblForma.Text = "Forma farmacéutica";
            // 
            // lblPrincipio
            // 
            lblPrincipio.AutoSize = true;
            lblPrincipio.Location = new Point(103, 116);
            lblPrincipio.Name = "lblPrincipio";
            lblPrincipio.Size = new Size(111, 20);
            lblPrincipio.TabIndex = 1;
            lblPrincipio.Text = "Principio activo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(103, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(133, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre comercial";
            // 
            // FrmProductosFarmaceuticos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 667);
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
    }
}