using consultar.datos.Helper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public DataTable Consultar(string nombreSP)
        {

            DataTable tabla = new DataTable();

            conexion.Open();

            SqlCommand comando = new SqlCommand(nombreSP, conexion);

            comando.CommandType = CommandType.StoredProcedure;

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;

        }

        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros)
        {

            conexion.Open();

            SqlCommand comando = new SqlCommand(nombreSP, conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();

            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Clave, p.Valor);
            }

            DataTable tabla = new DataTable();

            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;

        }

        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                t = conexion.BeginTransaction();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                    }
                }

                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();

            }

            return afectadas;
        }



    }
}
