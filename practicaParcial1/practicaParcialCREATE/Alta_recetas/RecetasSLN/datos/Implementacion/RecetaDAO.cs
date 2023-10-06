using RecetasSLN.datos.Helper;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Implementacion
{
    public class RecetaDAO : IRecetaDAO
    {
        public List<Ingrediente> TraerIngredientes()
        {
            List<Ingrediente> lIngredientes = new List<Ingrediente>();

            DataTable dt = HelperDAO.getInstance().consultar("SP_CONSULTAR_INGREDIENTES");

            foreach (DataRow fila in dt.Rows)
            {

                int nro = Convert.ToInt32(fila[0].ToString());
                string nom = fila[1].ToString();
                string umed = fila[2].ToString();

                Ingrediente i = new Ingrediente(nro,nom,umed);

                lIngredientes.Add(i);

            }

            return lIngredientes;
        }

        public int TraerProximoIdReceta()
        {
            return HelperDAO.getInstance().ConsultarEscalar("SP_PROXIMO_ID","@next");
        }

        //GRABAR MAESTRO-DETALLE

        public bool CrearReceta(Receta oReceta)
        {

            bool resultado = true;

            SqlConnection conexion = HelperDAO.getInstance().GetConnection();

            SqlTransaction t = null;

            try
            {
                conexion.Open();

                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;

                comando.Transaction = t;

                comando.CommandType = CommandType.StoredProcedure;

                comando.CommandText = "SP_INSERTAR_RECETA";

                comando.Parameters.AddWithValue("@id_receta", oReceta.RecetaNro);
                comando.Parameters.AddWithValue("@tipo_receta", oReceta.TipoReceta);
                comando.Parameters.AddWithValue("@nombre", oReceta.Nombre);
                comando.Parameters.AddWithValue("@cheff", oReceta.Chef);

                comando.ExecuteNonQuery();

                int detalleNro = 1;

                SqlCommand cmdDetalle;

                foreach (DetalleReceta dr in oReceta.DetalleRecetas)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", conexion, t);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_detalle_receta",detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_receta", oReceta.RecetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", dr.Ingrediente.IngredienteID);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dr.Cantidad);


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
                    resultado = false;
                }
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
