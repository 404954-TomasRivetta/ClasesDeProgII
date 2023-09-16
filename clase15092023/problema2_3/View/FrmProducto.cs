using problema2_3.Entidades;
using problema2_3.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema2_3
{
    public partial class FrmProducto : Form
    {


        //TRABAJO CON UNA LISTA DE IProductos de interfaces productos
        List<IProducto> lProductos;

        TipoProducto miTipo;

        //ENUMERACION
        enum TipoProducto
        {
            Suelto,
            Pack
        }

        public FrmProducto()
        {
            InitializeComponent();

            lProductos= new List<IProducto>();

            miTipo = TipoProducto.Suelto;

        }

        private void rbtSuelto_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Medida";
            miTipo = TipoProducto.Suelto;

        }

        private void rbtPack_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Cantidad";
            miTipo = TipoProducto.Pack;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //VALIDAR DATOS DE ENTRADA
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Ingrese un codigo de producto", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese un precio de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMedidaCantidad.Text == "")
            {
                MessageBox.Show("Ingrese un valor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cod = int.Parse(txtCodigo.Text);
            string nom = txtNombre.Text;
            double pre = double.Parse(txtPrecio.Text);

            int canMed = int.Parse(txtMedidaCantidad.Text);

            //if (rbtSuelto.Checked)
            //if(miTipo.Equals(TipoProducto.suelto))
            if(miTipo==TipoProducto.Suelto)
            {
                Suelto s = new Suelto(cod,nom,pre,canMed);
                lProductos.Add(s);
            }
            //if(miTipo==TipoProducto.Pack)
            else
            {
                Pack p = new Pack(cod, nom, pre, canMed);
                lProductos.Add(p);
            }

            lstProductos.Items.Clear();
            //lstProductos.DataSource = lProductos;
            lstProductos.Items.AddRange(lProductos.ToArray());

            limpiarCampos();

        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtMedidaCantidad.Text = "";
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            double total = 0;
            //ahora encuentro interfaces de productos
            foreach (IProducto p in lProductos)
            {
                total += p.CalcularPrecio();
            }

            txtTotal.Text = total.ToString();

        }
    }
}
