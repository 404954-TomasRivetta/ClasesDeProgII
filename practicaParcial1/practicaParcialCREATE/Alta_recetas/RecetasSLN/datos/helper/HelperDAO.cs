using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Helper
{
    public class HelperDAO
    {
        private static HelperDAO instancia;

        private SqlConnection conexion;

        private HelperDAO()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=db_recetas;Integrated Security=True");
        }

        public static HelperDAO getInstance() {
            
            if (instancia == null)
            {
                instancia = new HelperDAO();
            }

            return instancia;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }

        //CONSULTAR PARA COMBO
        public DataTable consultar(string nombreSP) {

            conexion.Open();
            
            DataTable tabla = new DataTable();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        //TRAER PROXIMO ID
        public int ConsultarEscalar(string nombreSP,string paramSalida) {
            
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
    }
}
