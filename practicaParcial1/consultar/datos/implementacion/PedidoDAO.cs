using consultar.datos.Helper;
using consultar.datos.interfaz;
using consultar.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consultar.datos.implementacion
{
    public class PedidoDAO : IPedido
    {
        public List<Cliente> TraerClientes()
        {
            List<Cliente> lClientes = new List<Cliente>();

            DataTable tabla = DBHelper.getInstance().Consultar("SP_CONSULTAR_CLIENTES");

            foreach (DataRow fila in tabla.Rows)
            {
                int codC = Convert.ToInt32(fila[0]);
                string nombre = fila[1].ToString();
                string apellido = fila[2].ToString();
                int dni = Convert.ToInt32(fila[3]);
                int codPostal = Convert.ToInt32(fila[4]);

                Cliente c = new Cliente(codC,nombre,apellido,dni,codPostal);

                lClientes.Add(c);
            }

            return lClientes;
        }

        public List<Pedido> TraerPedidosFiltrados(DateTime fechaDesde, DateTime fechaHasta, int codCliente)
        {
            List<Pedido> lPedido = new List<Pedido>();

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", fechaDesde));
            lst.Add(new Parametro("@fecha_hasta", fechaHasta));
            lst.Add(new Parametro("@cliente", codCliente));

            DataTable tabla = DBHelper.getInstance().Consultar("SP_CONSULTAR_PEDIDOS", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                Pedido p = new Pedido();

                p.Codigo = int.Parse(fila[0].ToString());
                p.FechaEntrega = DateTime.Parse(fila[1].ToString());
                p.CodCliente = int.Parse(fila[3].ToString());

                lPedido.Add(p);
            }

            return lPedido;
        }

        public bool BorrarPedido(int nro)
        {
            bool aux = true;
            SqlConnection conexion = DBHelper.getInstance().getConexion();
            SqlTransaction transaccion = null;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand("SP_REGISTRAR_BAJA", conexion, transaccion);
                comando.CommandType = CommandType.StoredProcedure;
                Parametro param = new Parametro("@codigo", nro);
                comando.Parameters.AddWithValue(param.Clave, param.Valor);
                comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return aux;
        }

        public bool EntregarPedido(int nro)
        {
            bool aux = true;
            SqlConnection conexion = DBHelper.getInstance().getConexion();
            SqlTransaction transaccion = null;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand("SP_REGISTRAR_ENTREGA", conexion, transaccion);
                comando.CommandType = CommandType.StoredProcedure;
                Parametro param = new Parametro("@codigo", nro);
                comando.Parameters.AddWithValue(param.Clave, param.Valor);
                comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    aux = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return aux;
        }
    }
}
