using SANNA.Negocio;
namespace SANNA.Presentacion;

public class FrmLogin : Form
{
    readonly TextBox txtU = new() { Left = 120, Top = 25, Width = 180 };
    readonly TextBox txtP = new() { Left = 120, Top = 60, Width = 180, UseSystemPasswordChar = true };
    readonly Label lblErr = new() { Left = 20, Top = 130, Width = 290, ForeColor = Color.Firebrick };

    public FrmLogin()
    {
        Text = "SANNA · Inicio de sesión"; ClientSize = new Size(330, 170); StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;
        var btn = new Button { Text = "Ingresar", Left = 120, Top = 95, Width = 100 };
        btn.Click += (_, _) => Ingresar();
        AcceptButton = btn;
        Controls.AddRange(new Control[] { new Label { Text = "Usuario", Left = 20, Top = 28 }, txtU,
            new Label { Text = "Contraseña", Left = 20, Top = 63 }, txtP, btn, lblErr });
    }

    void Ingresar()
    {
        try
        {
            var u = SeguridadNegocio.Autenticar(txtU.Text, txtP.Text);
            if (u == null) { lblErr.Text = "Usuario o contraseña incorrectos."; return; }
            Sesion.Actual = u; DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { lblErr.Text = "Error de conexión: " + ex.Message; }
    }
}
