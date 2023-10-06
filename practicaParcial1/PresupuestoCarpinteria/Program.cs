using PresupuestoCarpinteria.Presentacion;
using PresupuestoCarpinteria.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresupuestoCarpinteria
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
            //Application.Run(new FrmNuevoPresupuesto(new FabricaServicioImplementacion()));
            Application.Run(new FrmConsultar(new FabricaServicioImplementacion()));

        }
    }
}
