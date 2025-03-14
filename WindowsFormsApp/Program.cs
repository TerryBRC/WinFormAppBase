using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Utils;
using WindowsFormsApp.Views;

namespace WindowsFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VerificarConexion verificador = new VerificarConexion();

            if (!verificador.EsConexionValida())
            {
                FormConfiguracion configForm = new FormConfiguracion();
                configForm.ShowDialog();

                if (!verificador.EsConexionValida())
                {
                    MessageBox.Show("No se pudo conectar a la base de datos. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Application.Run(new FormInicio());
        }
    }
}
