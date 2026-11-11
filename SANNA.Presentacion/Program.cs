using SANNA.Negocio;
namespace SANNA.Presentacion;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        using (var login = new FrmLogin()) { if (login.ShowDialog() != DialogResult.OK) return; }
        Application.Run(new FrmMenu());
    }
}
