using PresupuestoCarpinteria.Entidades;
using PresupuestoCarpinteria.Servicios;
using PresupuestoCarpinteria.Servicios.interfaz;
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
    public partial class FrmConsultar : Form
    {

        IServicio servicio = null;

        public FrmConsultar(FabricaServicio fabrica)
        {
            InitializeComponent();

            servicio = fabrica.CrearServicio();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpFecDesde.Value = DateTime.Today.AddDays(-30);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Presupuesto> lPresupuesto = servicio.ObtenerPresupuestosFiltrados(dtpFecDesde.Value,dtpFecHasta.Value,txtCliente.Text);

            dgvPresupuestos.Rows.Clear();

            foreach (Presupuesto p in lPresupuesto)
            {
                dgvPresupuestos.Rows.Add(new object[] { 
                
                    p.PresupuestoNro,
                    p.Fecha,
                    p.Cliente,
                    p.Descuento,
                   
                });
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int nroOrden = Convert.ToInt32(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value.ToString());

            if (servicio.BorrarOrden(nroOrden))
            {
                MessageBox.Show("SE dio de baja");
            }
            else
            {
                MessageBox.Show("NO se dio de baja");
            }
        }
    }
}
