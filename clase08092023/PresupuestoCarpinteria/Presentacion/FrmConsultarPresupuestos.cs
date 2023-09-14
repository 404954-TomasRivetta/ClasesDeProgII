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
    public partial class FrmConsultarPresupuestos : Form
    {
        public FrmConsultarPresupuestos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void FrmConsultarPresupuestos_Load(object sender, EventArgs e)
        {
            //SIETE DIAS PARA ATRAS DE HOY
            dtpFecDesde.Value = DateTime.Now.AddDays(-7);
            //FECHA DE HOY
            dtpFecHasta.Value = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //VALIDAR datos de entrada
            List<Parametro> lista = new List<Parametro>();

            lista.Add(new Parametro("@fecha_desde", dtpFecDesde.Value.ToString("yyyy/MM/dd")));
            lista.Add(new Parametro("@fecha_hasta", dtpFecHasta.Value.ToString("yyyy/MM/dd")));
            lista.Add(new Parametro("@cliente", txtCliente.Text));

            DataTable tabla = new DBHelper().ConsultarTabla("SP_CONSULTAR_PRESUPUESTOS", lista);
            dgvPresupuestos.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgvPresupuestos.Rows.Add(new object[]
                {
                    fila["presupuesto_nro"].ToString(),
                    //PRIMERO LO PASO A DATETIME Y DEPUES COMO SHORT
                    ((DateTime)fila["fecha"]).ToShortDateString(),
                    fila["cliente"].ToString(),
                    fila["total"].ToString()
                });
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresupuestos.CurrentCell.ColumnIndex == 4)
            {
                //int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value.ToString());
                int nro = Convert.ToInt32(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value);

                FrmDetallePresupuesto frmDetallePresupuesto = new FrmDetallePresupuesto(nro);
                frmDetallePresupuesto.ShowDialog();
            }
        }
    }
}
