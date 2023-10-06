using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Datos.Helper
{
    public class DBHelper
    {
        private static DBHelper instancia;

        private SqlConnection conexion;

        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=carrera_planes_de_estudio;Integrated Security=True");
        }

        public static DBHelper ObtenerInstancia() {

            if (instancia == null)
            {
                instancia = new DBHelper();
            }

            return instancia;

        }

        public SqlConnection ObtenerConexion() {

            return conexion;
        }

        private void Conectar() { 
        
            conexion.Open();
        }

        private void Desconectar()
        {
            conexion.Close();
        }

        public DataTable Consultar(string nombreSP) 
        { 

            Conectar();

            DataTable dt = new DataTable();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            dt.Load(comando.ExecuteReader());

            Desconectar();

            return dt;
        }

        public int ObtenerProximoId(string nombreSP,string paramSal)
        {

            Conectar();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            SqlParameter parametro = new SqlParameter();

            parametro.ParameterName = paramSal;

            parametro.SqlDbType = SqlDbType.Int;

            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            Desconectar();

            return (int)parametro.Value;

        }
    }
}
