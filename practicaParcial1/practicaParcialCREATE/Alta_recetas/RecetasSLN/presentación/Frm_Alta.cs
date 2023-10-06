
using RecetasSLN.dominio;
using RecetasSLN.servicios;
using RecetasSLN.servicios.interfaz;
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

namespace RecetasSLN
{
    public partial class Frm_Alta : Form
    {

        IServicio servicio = null;

        Receta nuevo = null;

        public Frm_Alta(FabricaServicio fabrica)
        {
            InitializeComponent();

            servicio = fabrica.CrearServicio();

            nuevo = new Receta();
        }

        private void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            CargarProximoId();
            CargarCombo();
        }

        private void CargarProximoId()
        {
            lblNro.Text = "Receta #: " + servicio.TraerProximoIdReceta().ToString();
        }

        private void CargarCombo()
        {
            cboProducto.DataSource = servicio.TraerIngredientes();
            cboProducto.ValueMember = "IngredienteID";
            cboProducto.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un ingrediente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ingrediente"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este ingrediente ya esta en la receta...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Ingrediente i = (Ingrediente)cboProducto.SelectedItem;

            int cant = Convert.ToInt32(nudCantidad.Value);

            DetalleReceta detalle = new DetalleReceta(i,cant);

            nuevo.AgregarReceta(detalle);

            dgvDetalles.Rows.Add(new object[] {i.IngredienteID,i.Nombre,cant,"Quitar"});

            CargarTotalIngredientes();

        }

        private void CargarTotalIngredientes()
        {
            lblTotalIngredientes.Text = "Total de ingredientes: " + dgvDetalles.RowCount;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                nuevo.Eliminar(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);

                CargarTotalIngredientes();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el nombre de receta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCheff.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un cheff", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de comida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (servicio.CrearReceta(nuevo))
            {
                MessageBox.Show("Se registro la reseta");
            }
            else
            {
                MessageBox.Show("NO se registro la reseta");

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la receta?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
