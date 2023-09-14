using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PresupuestoCarpinteria.Entidades;

namespace PresupuestoCarpinteria.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {

        Presupuesto nuevo;

        public FrmNuevoPresupuesto()
        {
            InitializeComponent();

            nuevo= new Presupuesto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la operacion?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            //txtFecha.Text = DateTime.Today.ToShortDateString();
            txtFecha.Text = DateTime.Today.ToString("d");
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            ProximoPresupuesto();
            CargarProductos();
            btnAceptar.Enabled = false;
        }

        private void CargarProductos()
        {
            //creo la conexion
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";

            conexion.Open();

            //creo el comando
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            //que tipo de comando ejecuta
            comando.CommandType = CommandType.StoredProcedure;
            //le paso el nombre del sp a ejecutar
            comando.CommandText = "SP_CONSULTAR_PRODUCTOS";

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            //cargar combo box
            cboProducto.DataSource = tabla;
            cboProducto.ValueMember = "id_producto";
            cboProducto.DisplayMember = "n_producto";
            //cboProducto.ValueMember = tabla.Columns[0].ColumnName;
            //cboProducto.DisplayMember = tabla.Columns[1].ColumnName;

        }

        private void ProximoPresupuesto()
        {
            //creo la conexion
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";

            conexion.Open();

            //creo el comando
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            //que tipo de comando ejecuta
            comando.CommandType = CommandType.StoredProcedure;
            //le paso el nombre del sp a ejecutar
            comando.CommandText = "SP_PROXIMO_ID";

            //PARA RECIBIR EL PARAMETRO ª DEFINO EL PARAMETRO
            SqlParameter parametro = new SqlParameter();

            //TIENE QUE LLAMARSE IGUAL QUE EN EL SP
            parametro.ParameterName = "@next";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction= ParameterDirection.Output;
            
            //añado el parametro al comando
            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            conexion.Close();

            lblPresupuestoNro.Text = lblPresupuestoNro.Text + ": "+ parametro.Value.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto..","Control",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text,out _) || Convert.ToInt32(txtCantidad.Text) <= 0) {
                MessageBox.Show("Debe ingresar una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvDetalles.Rows) {
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
            
            Producto p = new Producto(nro,nom,pre);

            int cant = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto detalle = new DetallePresupuesto(p,cant);

            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(detalle.Producto.ProductoNro,
                detalle.Producto.Nombre,
                detalle.Producto.Precio,
                detalle.Cantidad,
                "Quitar");

            CalcularTotales();

            btnAceptar.Enabled = true;
        }

        private void CalcularTotales()
        {
            double total = nuevo.CalcularTotal();
            txtSubTotal.Text = total.ToString();

            double dto = total * Convert.ToDouble(txtDescuento.Text) / 100;

            txtTotal.Text = (total-dto).ToString();

        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
