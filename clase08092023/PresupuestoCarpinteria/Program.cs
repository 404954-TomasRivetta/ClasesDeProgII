using PresupuestoCarpinteria.Presentacion;
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
            Application.Run(new FrmPrincipal());

            //LO COMENTO YA QUE VOY A TRABAJAR EN SI CON EL FORMULARIO NUEVO PRESUPUESTO
            //Application.Run(new FrmPrincipal());
            //Application.Run(new FrmNuevoPresupuesto());

            /*
             aplico un data grid, al cual le voy a agregar las columnas necesarias, exceptuando la primera columna
            que no debe ser visible y ademas debo desmarcar los check que vienen marcados con la datagrid de forma predeterminada

             */
        }
    }
}
