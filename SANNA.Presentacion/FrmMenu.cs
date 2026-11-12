using SANNA.Negocio;
using SANNA.Presentacion.Contenedores;
namespace SANNA.Presentacion;

public class FrmMenu : Form
{
    private Form? formularioActual;
    public FrmMenu()
    {
        InitializeComponent();

        ConfigurarBotonesSidebar();

        Text = $"SANNA · Farmacovigilancia — {Sesion.Actual.NombreUsuario} ({Sesion.Actual.Rol})";

        lblUsuario.Text = $"{Sesion.Actual.NombreUsuario} ({Sesion.Actual.Rol})";

        btnPacientes.Visible = Sesion.Puede("pacientes");
        btnLotes.Visible = Sesion.Puede("lotes");
    }

    private void ConfigurarBotonesSidebar()
    {
        Button[] botones =
     {
        btnPacientes,
        btnLotes,
        btnProductosFarmaceuticos,
        btnEspecialidades
    };

        foreach (Button boton in botones)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.UseVisualStyleBackColor = false;

            boton.BackColor = Color.Transparent;
            boton.ForeColor = Color.DarkOliveGreen;

            boton.FlatAppearance.BorderSize = 0;

            boton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            boton.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
        }
    }

    private void ActualizarBotonActivo(Button botonSeleccionado)
    {
        Button[] botones =
    {
        btnPacientes,
        btnLotes,
        btnProductosFarmaceuticos,
        btnEspecialidades
    };

        foreach (Button boton in botones)
        {
            bool activo = boton == botonSeleccionado;

            boton.BackColor = activo
                ? Color.DarkOliveGreen
                : Color.Transparent;

            boton.ForeColor = activo
                ? Color.White
                : Color.DarkOliveGreen;

            boton.FlatAppearance.BorderSize = 0;

            boton.FlatAppearance.MouseOverBackColor = activo
                ? Color.DarkOliveGreen
                : Color.Transparent;

            boton.FlatAppearance.MouseDownBackColor = activo
                ? Color.DarkOliveGreen
                : Color.Transparent;
        }
    }
    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        pictureBox1 = new PictureBox();
        btnProductosFarmaceuticos = new Button();
        btnEspecialidades = new Button();
        label2 = new Label();
        btnCerrarSesion = new Button();
        btnLotes = new Button();
        btnPacientes = new Button();
        lblUsuario = new Label();
        pnlContenido = new Panel();
        pnlSidebar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.Transparent;
        pnlSidebar.BackgroundImage = Properties.Resources.color1;
        pnlSidebar.Controls.Add(pictureBox1);
        pnlSidebar.Controls.Add(btnProductosFarmaceuticos);
        pnlSidebar.Controls.Add(btnEspecialidades);
        pnlSidebar.Controls.Add(label2);
        pnlSidebar.Controls.Add(btnCerrarSesion);
        pnlSidebar.Controls.Add(btnLotes);
        pnlSidebar.Controls.Add(btnPacientes);
        pnlSidebar.Controls.Add(lblUsuario);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(250, 979);
        pnlSidebar.TabIndex = 0;
        // 
        // pictureBox1
        // 
        pictureBox1.BackgroundImage = Properties.Resources.logoSb;
        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBox1.Location = new Point(7, 26);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(235, 74);
        pictureBox1.TabIndex = 8;
        pictureBox1.TabStop = false;
        // 
        // btnProductosFarmaceuticos
        // 
        btnProductosFarmaceuticos.FlatStyle = FlatStyle.Flat;
        btnProductosFarmaceuticos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnProductosFarmaceuticos.Location = new Point(0, 358);
        btnProductosFarmaceuticos.Name = "btnProductosFarmaceuticos";
        btnProductosFarmaceuticos.Size = new Size(250, 66);
        btnProductosFarmaceuticos.TabIndex = 6;
        btnProductosFarmaceuticos.Text = "Productos Farmaceuticos";
        btnProductosFarmaceuticos.UseVisualStyleBackColor = true;
        btnProductosFarmaceuticos.Click += btnProductosFarmaceuticos_Click;
        // 
        // btnEspecialidades
        // 
        btnEspecialidades.FlatStyle = FlatStyle.Flat;
        btnEspecialidades.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEspecialidades.Location = new Point(0, 422);
        btnEspecialidades.Name = "btnEspecialidades";
        btnEspecialidades.Size = new Size(250, 66);
        btnEspecialidades.TabIndex = 7;
        btnEspecialidades.Text = "Especialidades";
        btnEspecialidades.UseVisualStyleBackColor = true;
        btnEspecialidades.Click += btnEspecialidades_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.ForeColor = Color.DarkOliveGreen;
        label2.Location = new Point(4, 106);
        label2.Name = "label2";
        label2.Size = new Size(99, 23);
        label2.TabIndex = 5;
        label2.Text = "Bienvenido";
        // 
        // btnCerrarSesion
        // 
        btnCerrarSesion.BackColor = Color.IndianRed;
        btnCerrarSesion.FlatStyle = FlatStyle.Flat;
        btnCerrarSesion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnCerrarSesion.ForeColor = SystemColors.ButtonFace;
        btnCerrarSesion.Location = new Point(0, 913);
        btnCerrarSesion.Name = "btnCerrarSesion";
        btnCerrarSesion.Size = new Size(250, 66);
        btnCerrarSesion.TabIndex = 4;
        btnCerrarSesion.Text = "Cerrar sesion";
        btnCerrarSesion.UseVisualStyleBackColor = false;
        btnCerrarSesion.Click += btnCerrarSesion_Click;
        // 
        // btnLotes
        // 
        btnLotes.FlatStyle = FlatStyle.Flat;
        btnLotes.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnLotes.Location = new Point(0, 294);
        btnLotes.Name = "btnLotes";
        btnLotes.Size = new Size(250, 66);
        btnLotes.TabIndex = 3;
        btnLotes.Text = "Lotes";
        btnLotes.UseVisualStyleBackColor = true;
        btnLotes.Click += btnLotes_Click;
        // 
        // btnPacientes
        // 
        btnPacientes.FlatStyle = FlatStyle.Flat;
        btnPacientes.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnPacientes.Location = new Point(0, 230);
        btnPacientes.Name = "btnPacientes";
        btnPacientes.Size = new Size(250, 66);
        btnPacientes.TabIndex = 2;
        btnPacientes.Text = "Pacientes";
        btnPacientes.UseVisualStyleBackColor = true;
        btnPacientes.Click += btnPacientes_Click;
        // 
        // lblUsuario
        // 
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblUsuario.ForeColor = SystemColors.ControlDarkDark;
        lblUsuario.Location = new Point(22, 137);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(19, 23);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "x";
        // 
        // pnlContenido
        // 
        pnlContenido.Dock = DockStyle.Right;
        pnlContenido.Location = new Point(251, 0);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new Size(1155, 979);
        pnlContenido.TabIndex = 1;
        // 
        // FrmMenu
        // 
        ClientSize = new Size(1406, 979);
        Controls.Add(pnlContenido);
        Controls.Add(pnlSidebar);
        Name = "FrmMenu";
        StartPosition = FormStartPosition.CenterScreen;
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);

    }

    private Panel pnlSidebar;
    private Button btnCerrarSesion;
    private Button btnLotes;
    private Button btnPacientes;
    private Label lblUsuario;
    private Label label2;
    private Button btnProductosFarmaceuticos;
    private Panel pnlContenido;
    private PictureBox pictureBox1;
    private Button btnEspecialidades;

    private void btnPacientes_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmPacientes(), btnPacientes);
    }

    private void btnLotes_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmLotes(), btnLotes);
    }

    private void CargarFormulario(Form formulario, Button botonSeleccionado)
    {
        ActualizarBotonActivo(botonSeleccionado);

        if (formularioActual != null)
        {
            pnlContenido.Controls.Remove(formularioActual);
            formularioActual.Dispose();
        }

        formulario.TopLevel = false;
        formulario.FormBorderStyle = FormBorderStyle.None;
        formulario.Dock = DockStyle.Fill;

        pnlContenido.Controls.Add(formulario);
        formulario.Show();

        formularioActual = formulario;
    }

    private void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnProductosFarmaceuticos_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmProductosFarmaceuticos(), btnProductosFarmaceuticos);
    }

    private void btnEspecialidades_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmEspecialidades(), btnEspecialidades);
    }

}