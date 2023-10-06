
using problema1_1.Entidades;
using problema1_1.Servicios;
using problema1_1.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_1
{
    public partial class FrmNuevoPlanDeEstudio : Form
    {

        Carrera nueva = null;

        IServicio servicio = null;

        public FrmNuevoPlanDeEstudio(FabricaServicio fabrica)
        {
            InitializeComponent();

            servicio = fabrica.CrearServicio();

            nueva = new Carrera();
        }

        private void FrmNuevoPlanDeEstudio_Load(object sender, EventArgs e)
        {
            CargarProximoId();
            CargarProductos();

        }

        private void CargarProximoId()
        {
            lblProximaCarrera.Text = "Carrera N° "+ servicio.ObtenerProximoID().ToString();
        }

        private void CargarProductos()
        {
            cboMateria.DataSource = servicio.ObtenerAsignaturas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea cancelar la operacion?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtAnioCursado.Text) > DateTime.Today.Year || txtAnioCursado.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un año valido","Error",MessageBoxButtons.OK);
                return;
            }
            if (numCuatrimestre.Value <= 0 || numCuatrimestre.Value >= 3 )
            {
                MessageBox.Show("Ingrese un cuatrimestre valido", "Error", MessageBoxButtons.OK);
                return;
            }
            if (cboMateria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una materia", "Error", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow row in dgvDetalleCarrera.Rows)
            {
                if (row.Cells["ColMateria"].Value.ToString().Equals(cboMateria.Text))
                {
                    MessageBox.Show("Ya ingreso esa materia", "Error", MessageBoxButtons.OK);
                    return;
                }                
            }

            Asignatura a = (Asignatura)cboMateria.SelectedItem;

            int anio = Convert.ToInt32(txtAnioCursado.Text);

            int cuatri = Convert.ToInt32(numCuatrimestre.Value);

            DetalleCarrera dc = new DetalleCarrera(a,anio,cuatri);

            nueva.AgregarDetalle(dc);

            dgvDetalleCarrera.Rows.Add(new object[] {

                dc.Asignatura.CodAsignatura,
                dc.Asignatura.NombreAsignatura,
                dc.AnioCursado,
                dc.Cuatrimestre,
                "Quitar"

            });
            

        }
        private void dgvDetalleCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleCarrera.CurrentCell.ColumnIndex == 4)
            {
                nueva.QuitarDetalle(dgvDetalleCarrera.CurrentRow.Index);
                dgvDetalleCarrera.Rows.RemoveAt(dgvDetalleCarrera.CurrentRow.Index);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCarrera.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una carrera", "Error", MessageBoxButtons.OK);
                return;
            }
            if (txtTitulo.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un titulo para la carrera", "Error", MessageBoxButtons.OK);
                return;
            }
            if (dgvDetalleCarrera.RowCount <= 0)
            {
                MessageBox.Show("Ingrese una materia por lo menos", "Error", MessageBoxButtons.OK);
                return;
            }

            GrabarCarrera();
        }

        private void GrabarCarrera()
        {
            nueva.NombreCarrera = txtCarrera.Text;
            nueva.TituloCarrera = txtTitulo.Text;

            if (servicio.CrearCarrera(nueva))
            {
                MessageBox.Show("Se registro la carrera con exito", "Control", MessageBoxButtons.OK);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se logro registrar la carrera", "Control", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
