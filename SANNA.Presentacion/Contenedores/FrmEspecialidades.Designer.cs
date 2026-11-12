namespace SANNA.Presentacion.Contenedores
{
    partial class FrmEspecialidades
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
            dgvEspecialidades = new DataGridView();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEstado = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEspecialidades.Location = new Point(12, 198);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.Size = new Size(776, 145);
            dgvEspecialidades.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(12, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(164, 15);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "GESTIÓN DE ESPECIALIDADES";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 59);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(138, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre de especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 126);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 4;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 156);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(280, 23);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(233, 371);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(125, 42);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(449, 371);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 42);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(233, 428);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(125, 44);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEstado
            // 
            btnEstado.Location = new Point(449, 432);
            btnEstado.Name = "btnEstado";
            btnEstado.Size = new Size(133, 40);
            btnEstado.TabIndex = 9;
            btnEstado.Text = "Activar/Desactivar";
            btnEstado.UseVisualStyleBackColor = true;
            btnEstado.Click += btnEstado_Click;
            // 
            // FrmEspecialidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(btnEstado);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(dgvEspecialidades);
            Name = "FrmEspecialidades";
            Text = "FrmEspecialidades";
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEspecialidades;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEstado;
    }
}