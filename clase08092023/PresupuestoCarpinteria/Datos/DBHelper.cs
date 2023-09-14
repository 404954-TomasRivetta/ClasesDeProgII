using PresupuestoCarpinteria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Datos
{
    internal class DBHelper
    {
        private SqlConnection conexion;

        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=carpinteria_db;Integrated Security=True");

        }

        public int ProximoPresupuesto() {

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
            parametro.Direction = ParameterDirection.Output;

            //añado el parametro al comando
            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            conexion.Close();

            return (int)parametro.Value;
        }

        public DataTable ConsultarTabla(string nombreSP)
        {

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            //le paso el nombre del sp a ejecutar
            comando.CommandText = nombreSP;

            DataTable dt = new DataTable();

            dt.Load(comando.ExecuteReader());

            conexion.Close();

            return dt;

        }

        //PARA CONSULTA DE OFRMULARIO FRM CONSULTA PRESUPUESTO
        public DataTable ConsultarTabla(string nombreSP,List<Parametro> lstParametros) {

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            //le paso el nombre del sp a ejecutar
            comando.CommandText = nombreSP;

            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre,p.Valor);  
            }

            DataTable dt = new DataTable();

            dt.Load(comando.ExecuteReader());

            conexion.Close();

            return dt;

        }

        public bool ConfirmarPresupuesto(Presupuesto oPresupuesto)
        {
            bool resultado = true;

            SqlTransaction t = null;

            try
            {
                conexion.Open();

                //QIE SEA POR TRANSACCION
                t = conexion.BeginTransaction();

                //GRABAR MAESTRO ----------------------------------------------------------------------
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.Transaction = t;

                comando.CommandType = CommandType.StoredProcedure;

                comando.CommandText = "SP_INSERTAR_MAESTRO";

                //LE PASO LOS PARAMETROS DE ENTRADA
                comando.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", oPresupuesto.CalcularTotal());

                //PARA RECIBIR EL PARAMETRO DE SALIDA DEFINO EL PARAMETRO
                SqlParameter parametro = new SqlParameter();

                //TIENE QUE LLAMARSE IGUAL QUE EN EL SP
                parametro.ParameterName = "@presupuesto_nro";

                parametro.SqlDbType = SqlDbType.Int;

                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                //GUARDO EL VALOR QUE DEVUELVE EL SP
                int presupuestoNro = (int)parametro.Value;

                //---------------------------GRABAR DETALLE ----------------
                //Numero de presupuesto 46, detalle 1,detalle 2 . Numero d epreuspuesto 47, detalle 1,detall 2
                int detalleNro = 1;

                SqlCommand cmdDetalle;

                foreach (DetallePresupuesto dp in oPresupuesto.Detalles)
                {
                    //LE PASO EL SP Y LA CONEXION POR PARAMETROS y tambien le paso que sea por transaccion
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion,t);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", dp.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);

                    cmdDetalle.ExecuteNonQuery();

                    detalleNro++;
                }

                //Confirma la transaccion
                t.Commit();

            }
            catch
            {
                //DEJA LA BASE DE DATOS COMO ESTABA, O TODO O NADA
                t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion!=null && conexion.State == ConnectionState.Open) { 
                    conexion.Close();
                }
            }
            return resultado;
        }



    }
}
