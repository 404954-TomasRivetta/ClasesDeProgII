using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Datos.Helper
{
    public class DBHelper
    {

        private static DBHelper instancia;

        private SqlConnection conexion;

        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=PCCESAR;Initial Catalog=db_carpinteria;Integrated Security=True");
        }

        public static DBHelper getInstance()
        {
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

        private void Conectar() { 
        
            conexion.Open();
        }

        private void Desconectar() {
            conexion.Close();
        }

        public DataTable Consultar(string nombreSP) {

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

        public int ObtenerProximoID(string nombreSP, string paramSalid) 
        {
            Conectar();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            SqlParameter parametro = new SqlParameter(paramSalid,SqlDbType.Int);

            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            Desconectar();

            return (int)parametro.Value;
        }

        public DataTable Consultar(string nombreSP,List<Parametro> lParam)
        {

            Conectar();

            DataTable dt = new DataTable();

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = nombreSP;

            comando.Parameters.Clear();
            foreach (Parametro p in lParam)
            {
                comando.Parameters.AddWithValue(p.Clave,p.Valor);
            }

            dt.Load(comando.ExecuteReader());

            Desconectar();

            return dt;

        }

    }
}
