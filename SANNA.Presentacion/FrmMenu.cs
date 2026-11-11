using SANNA.Negocio;
namespace SANNA.Presentacion;

public class FrmMenu : Form
{
    public FrmMenu()
    {
        Text = $"SANNA · Farmacovigilancia — {Sesion.Actual.NombreUsuario} ({Sesion.Actual.Rol})";
        WindowState = FormWindowState.Maximized; IsMdiContainer = true;
        var menu = new MenuStrip(); MainMenuStrip = menu; Controls.Add(menu);

        Agregar(menu, "Mantenedores", ("pacientes", "Pacientes", () => new FrmPacientes()), ("lotes", "Lotes", () => new FrmLotes()));
        // TODO por módulo (mismo patrón): citas, ingreso, atencion, administracion, sospecha, evaluacion, notificacion, seguimiento, consultas.
        var salir = new ToolStripMenuItem("Cerrar sesión"); salir.Click += (_, _) => Close(); menu.Items.Add(salir);
    }

    void Agregar(MenuStrip m, string titulo, params (string mod, string txt, Func<Form> f)[] items)
    {
        var raiz = new ToolStripMenuItem(titulo);
        foreach (var (mod, txt, f) in items)
        {
            if (!Sesion.Puede(mod)) continue;
            var it = new ToolStripMenuItem(txt); it.Click += (_, _) => { var fr = f(); fr.MdiParent = this; fr.Show(); };
            raiz.DropDownItems.Add(it);
        }
        if (raiz.DropDownItems.Count > 0) m.Items.Add(raiz);
    }
}
