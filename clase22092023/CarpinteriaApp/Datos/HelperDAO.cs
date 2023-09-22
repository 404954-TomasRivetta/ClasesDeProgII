using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos
{
    public class HelperDAO
    {

        private static HelperDAO instancia;

        private SqlConnection conexion;
        private HelperDAO()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);
        }
        // SELECICON PROPERTIS EN EL EXPLORADOR DE LA DERECHA-LO ABRO
        // RECURSOS
        // Y ASIGNO UN NOMBRE DE VARIABLE
        // Y EN VALOR LE COLOCO LA CADENA DE CONEXION SIN COMILLAS
        // Y LE AGREGO EL COMENTARIO QUE CREA algo que especifique que es

        public static HelperDAO ObtenerInstacia() 
        { 

            if(instancia == null)
            {
                instancia = new HelperDAO();
            }

            return instancia;
        }

        //PROXIMO NRO PRESUPUESTO - recibo el nombre del sp y el param de salida
        public int ConsultarEscalar(string nombreSP,string paramSalida)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = paramSalida;
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();

            return (int)parametro.Value;
        }

        //CARGAR COMBO GENERALIZADO
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        //para que PresupuestoDAO pueda acceder a la cadena de conexion
        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

        //TAREA: HACER ACA EL METODO DE GRABAR MAESTRO-DETALLE
    }
}
