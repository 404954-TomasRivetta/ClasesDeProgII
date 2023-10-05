using consultar.datos.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultar.datos
{
    public class DBHelper
    {

        private static DBHelper instancia;

        private SqlConnection conexion;

        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=db_pedidos;Integrated Security=True");
        }

        public static DBHelper getInstance() {

            if (instancia == null)
            {
                instancia = new DBHelper();
            }

            return instancia;
        }

        public SqlConnection getConexion()
        {
            return conexion;
        }

        public DataTable Consultar(string nombreSP) { 

            DataTable tabla = new DataTable();

            conexion.Open();

            SqlCommand comando = new SqlCommand(nombreSP,conexion);

            comando.CommandType = CommandType.StoredProcedure;

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;

        }

        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros) { 

            conexion.Open();

            SqlCommand comando = new SqlCommand(nombreSP,conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();

            foreach (Parametro p in  lstParametros)
            {
                comando.Parameters.AddWithValue(p.Clave,p.Valor);
            }
            
            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;

        }

    }
}
