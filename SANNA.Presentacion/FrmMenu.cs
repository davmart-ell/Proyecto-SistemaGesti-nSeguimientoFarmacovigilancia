using SANNA.Negocio;
namespace SANNA.Presentacion;

public class FrmMenu : Form
{
    private Form? formularioActual;
    public FrmMenu()
    {
        InitializeComponent();

        Text = $"SANNA · Farmacovigilancia — {Sesion.Actual.NombreUsuario} ({Sesion.Actual.Rol})";

        lblUsuario.Text = $"{Sesion.Actual.NombreUsuario} ({Sesion.Actual.Rol})";

        // Mostrar opciones según los permisos del usuario.
        btnPacientes.Visible = Sesion.Puede("pacientes");
        btnLotes.Visible = Sesion.Puede("lotes");
    }

    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        label2 = new Label();
        btnCerrarSesion = new Button();
        btnLotes = new Button();
        btnPacientes = new Button();
        lblUsuario = new Label();
        label1 = new Label();
        pnlContenido = new Panel();
        pnlSidebar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.Controls.Add(label2);
        pnlSidebar.Controls.Add(btnCerrarSesion);
        pnlSidebar.Controls.Add(btnLotes);
        pnlSidebar.Controls.Add(btnPacientes);
        pnlSidebar.Controls.Add(lblUsuario);
        pnlSidebar.Controls.Add(label1);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(250, 660);
        pnlSidebar.TabIndex = 0;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(3, 128);
        label2.Name = "label2";
        label2.Size = new Size(104, 20);
        label2.TabIndex = 5;
        label2.Text = "Contenedores:";
        // 
        // btnCerrarSesion
        // 
        btnCerrarSesion.Location = new Point(-1, 582);
        btnCerrarSesion.Name = "btnCerrarSesion";
        btnCerrarSesion.Size = new Size(250, 66);
        btnCerrarSesion.TabIndex = 4;
        btnCerrarSesion.Text = "Cerrar sesion";
        btnCerrarSesion.UseVisualStyleBackColor = true;
        btnCerrarSesion.Click += btnCerrarSesion_Click;
        // 
        // btnLotes
        // 
        btnLotes.Location = new Point(0, 215);
        btnLotes.Name = "btnLotes";
        btnLotes.Size = new Size(250, 66);
        btnLotes.TabIndex = 3;
        btnLotes.Text = "Lotes";
        btnLotes.UseVisualStyleBackColor = true;
        btnLotes.Click += btnLotes_Click;
        // 
        // btnPacientes
        // 
        btnPacientes.Location = new Point(0, 151);
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
        lblUsuario.Location = new Point(21, 61);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(16, 20);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "x";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(21, 27);
        label1.Name = "label1";
        label1.Size = new Size(59, 20);
        label1.TabIndex = 0;
        label1.Text = "SANNA";
        // 
        // pnlContenido
        // 
        pnlContenido.Dock = DockStyle.Right;
        pnlContenido.Location = new Point(254, 0);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new Size(965, 660);
        pnlContenido.TabIndex = 1;
        // 
        // FrmMenu
        // 
        ClientSize = new Size(1219, 660);
        Controls.Add(pnlContenido);
        Controls.Add(pnlSidebar);
        Name = "FrmMenu";
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        ResumeLayout(false);

    }

    private Panel pnlSidebar;
    private Button btnCerrarSesion;
    private Button btnLotes;
    private Button btnPacientes;
    private Label lblUsuario;
    private Label label1;
    private Label label2;
    private Panel pnlContenido;

    private void btnPacientes_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmPacientes());
    }

    private void btnLotes_Click(object sender, EventArgs e)
    {
        CargarFormulario(new FrmLotes());
    }

    private void CargarFormulario(Form formulario)
    {
        // Retirar el formulario anterior.
        if (formularioActual != null)
        {
            pnlContenido.Controls.Remove(formularioActual);
            formularioActual.Dispose();
        }

        // Configurar el nuevo formulario.
        formulario.TopLevel = false;
        formulario.FormBorderStyle = FormBorderStyle.None;
        formulario.Dock = DockStyle.Fill;

        // Cargarlo directamente en pnlContenido.
        pnlContenido.Controls.Add(formulario);

        formulario.Show();

        formularioActual = formulario;
    }

    private void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Close();
    }
}
