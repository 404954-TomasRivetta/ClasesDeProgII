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
    public partial class FrmNuevoPresupuesto : Form
    {

        Presupuesto nuevo = null;

        IServicio servicio = null;

        public FrmNuevoPresupuesto(FabricaServicio fabrica)
        {
            InitializeComponent();

            nuevo = new Presupuesto();

            servicio = fabrica.CrearServicio();

        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarNroPresupuesto();
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtDescuento.Text = "0";
            txtCliente.Text = "Consumidor Final";
        }

        private void CargarNroPresupuesto()
        {
            lblPresupuestoNro.Text = "Presupuesto Nº " + servicio.ObtenerProximoID().ToString();
        }

        private void CargarCombo()
        {
            cboProducto.DataSource = servicio.ObtenerProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            if (txtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una cantidad");
                return;
            }

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ColProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Ese producto ya fue ingresado");
                    return;
                }
            }

            Producto p = (Producto)cboProducto.SelectedItem;

            int cant = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto dt = new DetallePresupuesto(p,cant);

            nuevo.AgregarDetalle(dt);

            dgvDetalles.Rows.Add(new object[] { 
                
                dt.Producto.ProductoNro,
                dt.Producto.Nombre,
                dt.Producto.Precio,
                dt.Cantidad,
                "Quitar"
               
            });

            CalcularTotales();

        }

        private void CalcularTotales()
        {
            txtSubTotal.Text = nuevo.CalcularTotal().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
                txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un cliente");
                return;
            }
            if (dgvDetalles.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese un producto al menos");
                return;
            }

            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDescuento.Text);

            if (servicio.CrearPresupuesto(nuevo))
            {
                MessageBox.Show("Se registro el presupuesto con exito");
                
            }
            else
            {
                MessageBox.Show("No se registro el presupuesto");
                return;
            }
        }
    }
}
