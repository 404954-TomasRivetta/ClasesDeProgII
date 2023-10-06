using PresupuestoCarpinteria.Datos.Helper;
using PresupuestoCarpinteria.Datos.Interfaz;
using PresupuestoCarpinteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Datos.Implementacion
{
    public class PresupuestoDAO : IPresupuestoDAO
    {
        public bool CrearPresupuesto(Presupuesto oPresupuesto)
        {

            bool resultado = true;

            SqlConnection conexion = DBHelper.getInstance().getConexion();

            SqlTransaction t = null;

            try
            {

                conexion.Open();

                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_INSERTAR_MAESTRO",conexion,t);

                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotal());

                SqlParameter parametro = new SqlParameter("@presupuesto_nro", SqlDbType.Int);

                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int nroPresupuesto = (int)parametro.Value;

                int detalleNro = 1;

                SqlCommand cmdDetalle;

                foreach (DetallePresupuesto dp in oPresupuesto.Detalles)
                {

                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", nroPresupuesto);
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
                {
                    t.Rollback();
                }
                resultado = false;

            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resultado;
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> lProductos = new List<Producto>();

            DataTable dt = DBHelper.getInstance().Consultar("SP_CONSULTAR_PRODUCTOS");

            foreach (DataRow row in dt.Rows)
            {

                int nro = Convert.ToInt32(row[0].ToString());

                string nom = Convert.ToString(row[1].ToString());

                double pre = Convert.ToDouble(row[2].ToString());

                Producto p = new Producto(nro,nom,pre);

                lProductos.Add(p);
            }

            return lProductos;
        }

        public int ObtenerProximoID()
        {
            return DBHelper.getInstance().ObtenerProximoID("SP_PROXIMO_ID","@next");
        }









        public List<Presupuesto> ObtenerPresupuestosFiltrados(DateTime fechaDesde, DateTime fechaHasta, string cliente)
        {
            List<Presupuesto> lPresupuesto = new List<Presupuesto>();

            List<Parametro> lParam = new List<Parametro>();

            lParam.Add(new Parametro("@fecha_desde",fechaDesde));
            lParam.Add(new Parametro("@fecha_hasta", fechaHasta));
            lParam.Add(new Parametro("@cliente",cliente));

            DataTable dt = DBHelper.getInstance().Consultar("SP_CONSULTAR_PRESUPUESTOS",lParam);

            foreach (DataRow row in dt.Rows)
            {
                Presupuesto p = new Presupuesto();

                p.PresupuestoNro = Convert.ToInt32(row[0].ToString());
                p.Fecha = Convert.ToDateTime(row[1].ToString());
                p.Cliente = Convert.ToString(row[2].ToString());
                p.Descuento = Convert.ToDouble(row[5].ToString());
                lPresupuesto.Add(p);
            }

            return lPresupuesto;
        }

        public bool BorrarOrden(int nroOrden)
        {
            bool resultado = true;

            SqlConnection conexion = DBHelper.getInstance().getConexion();

            SqlTransaction t = null;

            try
            {

                conexion.Open();

                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_ELIMINAR_PRESUPUESTO", conexion, t);

                comando.CommandType = CommandType.StoredProcedure;

                Parametro parametro = new Parametro("@presupuesto_nro",nroOrden);

                comando.Parameters.AddWithValue(parametro.Clave, parametro.Valor);

                comando.ExecuteNonQuery();

                t.Commit();

            }
            catch
            {
                if (t != null)
                {
                    t.Rollback();
                }
                resultado = false;

            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resultado;
        }
    }
}
