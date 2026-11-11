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
        SuspendLayout();
        // 
        // btnIngresar
        // 
        btnIngresar.Location = new Point(124, 378);
        btnIngresar.Name = "btnIngresar";
        btnIngresar.Size = new Size(94, 29);
        btnIngresar.TabIndex = 0;
        btnIngresar.Text = "Ingresar";
        btnIngresar.UseVisualStyleBackColor = true;
        btnIngresar.Click += btnIngresar_Click_1;
        // 
        // txtP
        // 
        txtP.Location = new Point(69, 292);
        txtP.Name = "txtP";
        txtP.Size = new Size(205, 27);
        txtP.TabIndex = 1;
        txtP.UseSystemPasswordChar = true;
        // 
        // txtU
        // 
        txtU.Location = new Point(69, 182);
        txtU.Name = "txtU";
        txtU.Size = new Size(205, 27);
        txtU.TabIndex = 2;
        // 
        // lblErr
        // 
        lblErr.AutoSize = true;
        lblErr.Location = new Point(58, 438);
        lblErr.Name = "lblErr";
        lblErr.Size = new Size(0, 20);
        lblErr.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(59, 252);
        label1.Name = "label1";
        label1.Size = new Size(83, 20);
        label1.TabIndex = 4;
        label1.Text = "Contraseña";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(55, 138);
        label2.Name = "label2";
        label2.Size = new Size(59, 20);
        label2.TabIndex = 5;
        label2.Text = "Usuario";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(85, 58);
        label3.Name = "label3";
        label3.Size = new Size(172, 20);
        label3.TabIndex = 6;
        label3.Text = "SANNA · inicio de sesión";
        // 
        // FrmLogin
        // 
        ClientSize = new Size(356, 485);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(lblErr);
        Controls.Add(txtU);
        Controls.Add(txtP);
        Controls.Add(btnIngresar);
        Name = "FrmLogin";
        ResumeLayout(false);
        PerformLayout();

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
    private Button btnIngresar;
}
