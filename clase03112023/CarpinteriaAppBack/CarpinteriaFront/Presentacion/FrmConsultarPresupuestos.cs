using CarpinteriaBack.Entidades;
using CarpinteriaFront.Servicios;
using CarpinteriaFront.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaFront.Presentacion
{
    public partial class FrmConsultarPresupuestos : Form
    {

        IServicio servicio = null;

        public FrmConsultarPresupuestos(FabricaServicio fabrica)
        {
            InitializeComponent();

            servicio = fabrica.CrearServicio();

        }

        private void FrmConsultarPresupuestos_Load(object sender, EventArgs e)
        {
            dtpFecDesde.Value = DateTime.Now.AddDays(-7);
            dtpFecHasta.Value = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //validar campos de carga!!!

            List<Presupuesto> lPresupuestos = servicio.TraerPresupuestosFiltrados(dtpFecDesde.Value,dtpFecHasta.Value,txtCliente.Text);
            dgvPresupuestos.Rows.Clear();
            foreach (Presupuesto p in lPresupuestos)
            {
                dgvPresupuestos.Rows.Add(new object[] {
                    p.PresupuestoNro,
                    p.Fecha,
                    p.Cliente,
                    p.CalcularTotal(),
                    //la coma adicional es para la columna de acciones en el datagridview
                }) ;
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresupuestos.CurrentCell.ColumnIndex== 4) 
            {
                //int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value.ToString());
                int nro = Convert.ToInt32(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value);
                FrmDetallesPresupuesto detalle = new FrmDetallesPresupuesto(nro); //llamada con constructor con parámetro.
                detalle.presupuestoNro= nro; //llamada con propiedad.   
                detalle.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
