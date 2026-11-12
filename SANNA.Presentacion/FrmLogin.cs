using SANNA.Negocio;
namespace SANNA.Presentacion;

public class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        btnIngresar = new Button();
        txtP = new TextBox();
        txtU = new TextBox();
        lblErr = new Label();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        panel1 = new Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnIngresar
        // 
        btnIngresar.BackColor = Color.ForestGreen;
        btnIngresar.FlatStyle = FlatStyle.Flat;
        btnIngresar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnIngresar.ForeColor = SystemColors.ButtonFace;
        btnIngresar.Location = new Point(185, 575);
        btnIngresar.Name = "btnIngresar";
        btnIngresar.Size = new Size(138, 38);
        btnIngresar.TabIndex = 0;
        btnIngresar.Text = "Ingresar";
        btnIngresar.UseVisualStyleBackColor = false;
        btnIngresar.Click += btnIngresar_Click_1;
        // 
        // txtP
        // 
        txtP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        txtP.ForeColor = SystemColors.ControlDarkDark;
        txtP.Location = new Point(116, 475);
        txtP.Name = "txtP";
        txtP.Size = new Size(289, 30);
        txtP.TabIndex = 1;
        txtP.UseSystemPasswordChar = true;
        // 
        // txtU
        // 
        txtU.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        txtU.ForeColor = SystemColors.ControlDarkDark;
        txtU.Location = new Point(116, 341);
        txtU.Name = "txtU";
        txtU.Size = new Size(289, 30);
        txtU.TabIndex = 2;
        // 
        // lblErr
        // 
        lblErr.AutoSize = true;
        lblErr.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblErr.ForeColor = Color.DarkOliveGreen;
        lblErr.Location = new Point(122, 663);
        lblErr.Name = "lblErr";
        lblErr.Size = new Size(0, 23);
        lblErr.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.ForeColor = SystemColors.ControlDarkDark;
        label1.Location = new Point(116, 415);
        label1.Name = "label1";
        label1.Size = new Size(99, 23);
        label1.TabIndex = 4;
        label1.Text = "Contraseña";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.ForeColor = SystemColors.ControlDarkDark;
        label2.Location = new Point(116, 292);
        label2.Name = "label2";
        label2.Size = new Size(70, 23);
        label2.TabIndex = 5;
        label2.Text = "Usuario";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.DarkOliveGreen;
        label3.Location = new Point(185, 218);
        label3.Name = "label3";
        label3.Size = new Size(142, 25);
        label3.TabIndex = 6;
        label3.Text = "inicio de sesión";
        // 
        // panel1
        // 
        panel1.BackColor = Color.Transparent;
        panel1.BackgroundImage = Properties.Resources.Fmlogin;
        panel1.BackgroundImageLayout = ImageLayout.Stretch;
        panel1.Controls.Add(label3);
        panel1.Controls.Add(lblErr);
        panel1.Controls.Add(label1);
        panel1.Controls.Add(txtP);
        panel1.Controls.Add(txtU);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(btnIngresar);
        panel1.Dock = DockStyle.Left;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(519, 746);
        panel1.TabIndex = 7;
        // 
        // FrmLogin
        // 
        ClientSize = new Size(519, 746);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SANNA · login";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);

    }

    private void Ingresar()
    {
        try
        {
            lblErr.Text = "";

            var u = SeguridadNegocio.Autenticar(
                txtU.Text.Trim(),
                txtP.Text
            );

            if (u == null)
            {
                lblErr.Text = "Usuario o contraseña incorrectos.";
                txtP.Clear();
                txtP.Focus();
                return;
            }

            Sesion.Actual = u;
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblErr.Text = "Error de conexión: " + ex.Message;
        }
    }

    private void btnIngresar_Click_1(object sender, EventArgs e)
    {
        Ingresar();
    }

    private TextBox txtP;
    private TextBox txtU;
    private Label lblErr;
    private Label label1;
    private Label label2;
    private Label label3;
    private Panel panel1;
    private Button btnIngresar;
}
