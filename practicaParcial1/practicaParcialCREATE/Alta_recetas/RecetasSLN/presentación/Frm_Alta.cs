
using RecetasSLN.datos;
using RecetasSLN.dominio;
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
        private Receta nueva;
        private Gestor gestor;


        public Frm_Alta()
        {
            InitializeComponent();
            nueva = new Receta();
            gestor = new Gestor();
            ConsultarUltimaReceta();
        }

        private void ConsultarUltimaReceta()
        {
            lblNro.Text = "Receta #: " + gestor.ProximaReceta();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (txtCheff.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Chef", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCheff.Focus();
                return;
            }

            if (dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Debe ingresar 3 ingredientes como mínimo", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return;

            }
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Nombre", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }
            nueva.RecetaNro = gestor.ProximaReceta();   
            nueva.Nombre = txtNombre.Text;
            nueva.Chef = txtCheff.Text;
            nueva.TipoReceta = Convert.ToInt32(cboTipo.SelectedIndex);
            if (gestor.EjecutarInsert(nueva))
            {
                MessageBox.Show("Receta guardada");
                LimpiarCampos();
        
            }
            else
            {
                MessageBox.Show("Receta NO guardada");
            }

            
        }
            private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();

            }
            else
            {
                return;
            }
        }

        private void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            CargarCombo();
           
            
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
            txtCheff.Text = string.Empty;
            cboTipo.Text = string.Empty;
            dgvDetalles.Rows.Clear();
            lblTotalIngredientes.Text = "Total de ingredientes:";
            ConsultarUltimaReceta();
        }
        private void CargarCombo()
        {
            

            DataTable tabla = gestor.ListarIngredientes();
            cboProducto.DataSource = tabla;
            cboProducto.ValueMember = tabla.Columns[0].ColumnName;
            cboProducto.DisplayMember = tabla.Columns[1].ColumnName;
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un ingrediente", "Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(nudCantidad.Text) || !int.TryParse(nudCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["Ingrediente"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este ingrediente ya está cargado.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            DataRowView item = (DataRowView)cboProducto.SelectedItem;
            int ingr = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            
            Ingrediente i = new Ingrediente(ingr, nom);
            int cant = Convert.ToInt32(nudCantidad.Value);
            DetalleReceta detalle = new DetalleReceta(i, cant);

            nueva.AgregarReceta(detalle);

            dgvDetalles.Rows.Add(new object[] { ingr, nom, cant });

            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            lblTotalIngredientes.Text = "Total de ingredientes:" + dgvDetalles.Rows.Count;
        }
        private bool ExisteProductoEnGrilla(string text)
        {
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["producto"].Value.Equals(text))
                    return true;
            }
            return false;
        }

       



        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                nueva.Eliminar(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
            }
        }
    }
}
