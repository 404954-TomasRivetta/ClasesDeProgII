using PresupuestoCarpinteria.Datos;
using PresupuestoCarpinteria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresupuestoCarpinteria.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {

        Presupuesto nuevo;

        DBHelper gestor;

        public FrmNuevoPresupuesto()
        {
            InitializeComponent();

            nuevo = new Presupuesto();

            gestor = new DBHelper();
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {

            lblPresupuestoNro.Text = lblPresupuestoNro.Text + " " + gestor.ProximoPresupuesto().ToString();

            txtFecha.Text = DateTime.Today.ToString("d");
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";

            CargarProductos("SP_CONSULTAR_PRODUCTOS",cboProducto);
        }

        private void CargarProductos(string nombreSP, ComboBox combo)
        {
            DataTable tabla = new DataTable();
            tabla = gestor.ConsultarTabla(nombreSP);
            combo.DataSource = tabla;
            //combo.ValueMember = "id_producto";
            //combo.DisplayMember = "n_producto";
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
        }


        private void CalcularTotales()
        {
            double total = nuevo.CalcularTotal();
            txtSubTotal.Text = total.ToString();

            double dto = total * Convert.ToDouble(txtDescuento.Text) / 100;

            txtTotal.Text = (total - dto).ToString();

        }

        //Metodo para cuando acicona el boton quitar de la DATA GRID VIEW
        private void dgvDetalles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4) //es el boton quitar??
            {
                if (MessageBox.Show("Seguro desea quitar el elemento?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                    dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                    CalcularTotales();
                }
            }

            //if (e.ColumnIndex == 4) //es el boton quitar??
            //{
            //    if (MessageBox.Show("Seguro desea quitar el elemento?", "Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        nuevo.QuitarDetalle(e.RowIndex);
            //        dgvDetalles.Rows.RemoveAt(e.RowIndex);
            //        CalcularTotales();
            //    }
            //}
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _) || Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["ColProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este producto ya esta presupuestado..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //
            DataRowView item = (DataRowView)cboProducto.SelectedItem;

            //
            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);

            Producto p = new Producto(nro, nom, pre);

            int cant = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto detalle = new DetallePresupuesto(p, cant);

            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(detalle.Producto.ProductoNro,
                detalle.Producto.Nombre,
                detalle.Producto.Precio,
                detalle.Cantidad,
                "Quitar");

            CalcularTotales();

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la operacion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //VALIDADOR
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Debe ingresar un cliente..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Grabar presuuesto M-D - IMPLICA GRABAR PRESUPUESTO Y DETALLE
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDescuento.Text);

            if (gestor.ConfirmarPresupuesto(nuevo))
            {
                MessageBox.Show("Se grabo con exito el presupesto..", 
                    "Informe", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                //cierra y elimina de la memoria el objeto, es para que se cierre y me mande al principal
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al registrar el presupuesto..", 
                    "Control", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

        }
    }
}
