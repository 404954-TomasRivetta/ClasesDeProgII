using CarpinteriaApp.Datos.Interfaz;
using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos.implementaciones
{
    public class PresupuestoDAO : IPresupuestoDAO
    {
        public int ObtenerProximoNro()
        {
            return HelperDAO.ObtenerInstacia().ConsultarEscalar("SP_PROXIMO_ID","@next");
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lProductos = new List<Producto>();

            DataTable tabla = HelperDAO.ObtenerInstacia().Consultar("SP_CONSULTAR_PRODUCTOS");

            foreach (DataRow fila  in tabla.Rows)
            {
                int nro = int.Parse(fila[0].ToString());
                string nom = fila[1].ToString();
                double pre = double.Parse(fila[2].ToString());

                Producto p = new Producto(nro,nom,pre);

                lProductos.Add(p);
            }
            
            return lProductos;
        }

        public bool Crear(Presupuesto oPresupuesto)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDAO.ObtenerInstacia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO";
                comando.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotal());

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@presupuesto_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int presupuestoNro = (int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;

                foreach (DetallePresupuesto dp in oPresupuesto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", dp.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }

        public List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime fechaDesde, DateTime fechaHasta, string cliente)
        {

            List<Presupuesto> lPresupuestos = new List<Presupuesto>();

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", fechaDesde));
            lst.Add(new Parametro("@fecha_hasta", fechaHasta));
            lst.Add(new Parametro("@cliente",cliente));

            DataTable tabla = HelperDAO.ObtenerInstacia().Consultar("SP_CONSULTAR_PRESUPUESTOS", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                Presupuesto p = new Presupuesto();

                p.PresupuestoNro = int.Parse(fila[0].ToString());
                p.Fecha = DateTime.Parse(fila["fecha"].ToString());
                p.Cliente= fila[2].ToString();
                p.Descuento = double.Parse(fila[3].ToString());

                lPresupuestos.Add(p);
            }

            return lPresupuestos;
        }

        public bool Actualizar(Presupuesto oPresupuesto)
        {
            throw new NotImplementedException();
        }

        public Presupuesto ObtenerPresupuestoPorNumero(int numero)
        {

            Presupuesto p = null;

            List<Presupuesto> lPresupuestos = new List<Presupuesto>();

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", numero));

            DataTable tabla = HelperDAO.ObtenerInstacia().Consultar("SP_CONSULTAR_DETALLES_PRESUPUESTO", lst);

            bool primero = true;

            foreach (DataRow fila in tabla.Rows)
            {
                p = new Presupuesto();

                if (primero)
                {
                    p.PresupuestoNro = int.Parse(fila["presupuesto_nro"].ToString());
                    p.Fecha = DateTime.Parse(fila["fecha"].ToString());
                    p.Cliente = fila["cliente"].ToString();
                    p.Descuento = double.Parse(fila["descuento"].ToString());
                    primero= false;
                }

                Producto pro = new Producto();

                pro.ProductoNro = int.Parse(fila["id_producto"].ToString());
                pro.Nombre = fila["n_producto"].ToString();
                pro.Precio = double.Parse(fila["precio"].ToString());

                int cant = int.Parse(fila["cantidad"].ToString());

                DetallePresupuesto detalle = new DetallePresupuesto(pro,cant);

                p.AgregarDetalle(detalle);
            }

            return p;
        }

        public bool Borrar(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
