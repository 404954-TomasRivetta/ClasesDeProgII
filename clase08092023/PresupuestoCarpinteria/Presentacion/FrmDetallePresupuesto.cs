using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresupuestoCarpinteria.Presentacion
{
    public partial class FrmDetallePresupuesto : Form
    {
        //LE PASO POR PARAMETRO EL ID DEL PRESUPUESTO ELEGIDO
        public FrmDetallePresupuesto(int presupuestoNro)
        {
            InitializeComponent();
            //me muestra el texto en la pantalla
            this.Text += presupuestoNro.ToString();
        }

        private void FrmDetallePresupuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
