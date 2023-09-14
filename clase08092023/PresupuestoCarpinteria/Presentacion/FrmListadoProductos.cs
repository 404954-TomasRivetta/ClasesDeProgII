using PresupuestoCarpinteria.Datos;
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
    public partial class FrmListadoProductos : Form
    {
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSProductos.TA_PRODUCTOS' Puede moverla o quitarla según sea necesario.

            //this.tA_PRODUCTOSTableAdapter.Fill(this.dSProductos.TA_PRODUCTOS);

            DataTable tabla = new DBHelper().ConsultarTabla("SP_CONSULTAR_PRODUCTOS");
            this.tAPRODUCTOSBindingSource.DataSource = tabla;

            this.reportViewer1.RefreshReport();
        }

        private void tAPRODUCTOSBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
