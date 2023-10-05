using consultar.datos;
using consultar.datos.Helper;
using consultar.entidades;
using consultar.Servicios;
using consultar.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace consultar.presentaciones
{
    public partial class FrmConsultar : Form
    {

        IServicio servicio = null;

        public FrmConsultar(FabricaServicio fabrica)
        {
            InitializeComponent();

            servicio = fabrica.CrearServicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarCombo();
        }

        private void CargarCombo()
        {
            cboClientes.DataSource = servicio.TraerClientes();
            cboClientes.ValueMember = "CodCliente";
            cboClientes.DisplayMember = "Nombre";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Pedido> lPedidos = servicio.TraerPedidosFiltrados(dtpDesde.Value, dtpHasta.Value, cboClientes.SelectedIndex+1);
            dgvPedidos.Rows.Clear();
            foreach (Pedido p in lPedidos)
            {
                dgvPedidos.Rows.Add(new object[] {
                    p.Codigo,
                    p.CodCliente,
                    p.FechaEntrega,
                    "Entregar",
                    "Eliminar"
                });
            }

            lblTotal.Text = "Total de pedidos: " + dgvPedidos.RowCount;
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Al seleccionar la opción Entregar deberá validar que el pedido no haya sido entregado.
            //Informar con un mensaje de confirmación si se actualizó o si ya había sido entregado.

            if (dgvPedidos.CurrentCell.ColumnIndex == 4)
            {

                int nro = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["colCodigo"].Value.ToString());

                servicio.EntregarPedido(nro);
            }

            if (dgvPedidos.CurrentCell.ColumnIndex == 5)
            {
                int nro = int.Parse(dgvPedidos.CurrentRow.Cells["colCodigo"].Value.ToString());

                servicio.BorrarOrden(nro);
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
