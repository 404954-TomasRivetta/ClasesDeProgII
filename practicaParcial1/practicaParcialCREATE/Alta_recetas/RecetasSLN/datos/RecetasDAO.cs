using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;

namespace RecetasSLN.datos
{
    class RecetasDAO : IRecetasDAO
    {

        public DataTable ListarIngredientes()
         {

                 SqlConnection conexion = new SqlConnection();
             conexion.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_recetas;Integrated Security=True";
             conexion.Open();
                 SqlCommand comando = new SqlCommand();
                 comando.Connection = conexion;
                 comando.CommandType = CommandType.StoredProcedure;
                 comando.CommandText = "SP_CONSULTAR_INGREDIENTES";
                 DataTable tabla = new DataTable();
                 tabla.Load(comando.ExecuteReader());
                     conexion.Close();

             return tabla;
         }
      
        public int ProximaReceta()
        {

            SqlParameter param = new SqlParameter("@proximo", SqlDbType.Int);
            SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=db_recetas;Integrated Security=True");
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_PROXIMA_RECETA";
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);
                comando.ExecuteNonQuery();
                return (int)param.Value;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
           
           
           
        }

        public bool EjecutarInsert(Receta oReceta)
        {
           
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=db_recetas;Integrated Security=True");
            bool ok = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();

                //Se inserta Receta
                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_RECETA", conexion, transaction);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                
                cmdMaestro.Parameters.AddWithValue("@id_receta", oReceta.RecetaNro);
                cmdMaestro.Parameters.AddWithValue("@tipo_receta", oReceta.TipoReceta);
                cmdMaestro.Parameters.AddWithValue("@nombre", oReceta.Nombre);
                if (oReceta.Chef != null)
                    cmdMaestro.Parameters.AddWithValue("@cheff", oReceta.Chef);
                else
                    cmdMaestro.Parameters.AddWithValue("@cheff", DBNull.Value);

                cmdMaestro.ExecuteNonQuery();
                int count = 1;
                //Se inserta Detalle Receta 
                foreach (DetalleReceta detalle in oReceta.DetalleRecetas)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", conexion, transaction);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", oReceta.RecetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", detalle.Ingrediente.IngredienteID);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    count++;
                    cmdDetalle.ExecuteNonQuery();
                    
                }
                transaction.Commit();
            }
            catch (Exception ex) { 
            transaction.Rollback();
                ok = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return ok;
        }
       
    }
}
