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
    public partial class FrmReporteProductosPresupuestados : Form
    {
        public FrmReporteProductosPresupuestados()
        {
            InitializeComponent();
        }

        private void FrmReporteProductosPresupuestados_Load(object sender, EventArgs e)
        {

            //ULTIMOS 30 DIAS
            dtpFecDesde.Value=DateTime.Now.AddDays(-30);
            dtpFecHasta.Value = DateTime.Now;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            List<Parametro> lista = new List<Parametro>();

            lista.Add(new Parametro("@fecha_desde",dtpFecDesde.Value));
            lista.Add(new Parametro("@fecha_hasta", dtpFecHasta.Value));

            //this.dTProductosPresupuestadosBindingSource.DataSource =new DBHelper().ConsultarTabla("SP_REPORTE_PRODUCTOS",lista);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", new DBHelper().ConsultarTabla("SP_REPORTE_PRODUCTOS", lista)));

            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
