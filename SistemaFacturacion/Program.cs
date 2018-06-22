using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion
    {
    static class Program
        {
        public static Seccion UsuarioActual;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
            {
            UsuarioActual = Seccion.Instance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Formularios.FrmArticulos());
             Application.Run(new Login());
            }
        }
    }
