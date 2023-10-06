using problema1_1.Datos.Helper;
using problema1_1.Datos.interfaz;
using problema1_1.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problema1_1.Datos.implementacion
{
    public class CarreraDAO : ICarreraDAO
    {
        public bool CrearCarrera(Carrera oCarrera)
        {
            bool result = true;

            SqlConnection conexion = DBHelper.ObtenerInstancia().ObtenerConexion();

            SqlTransaction t = null;

            try
            {
                conexion.Open();

                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand("sp_insertar_maestro",conexion,t);

                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre_carrera",oCarrera.NombreCarrera);

                comando.Parameters.AddWithValue("@titulo", oCarrera.TituloCarrera);

                SqlParameter parametro = new SqlParameter("@id_carrera",SqlDbType.Int);


                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);
               
                comando.ExecuteNonQuery();

                int nro_carrera = (int)parametro.Value;

                int detalleNro = 1;

                SqlCommand cmdDetalle;

                foreach (DetalleCarrera dc in oCarrera.Detalles)
                {
                    cmdDetalle = new SqlCommand("sp_insertar_detalle",conexion,t);

                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_carrera", nro_carrera);
                    cmdDetalle.Parameters.AddWithValue("@id_detalle",detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@anioCursado",dc.AnioCursado);
                    cmdDetalle.Parameters.AddWithValue("@cuatrimestre",dc.Cuatrimestre);
                    cmdDetalle.Parameters.AddWithValue("@id_asignatura",dc.Asignatura.CodAsignatura);

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
                    result = false;
                }
            }
            finally {

                if (conexion != null & conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return result;
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            List<Asignatura> lAsignaturas = new List<Asignatura>();

            DataTable tabla = new DataTable();

            tabla = DBHelper.ObtenerInstancia().Consultar("sp_consultar_asignaturas");

            foreach (DataRow fila in tabla.Rows)
            {
                int cod = Convert.ToInt32(fila[0].ToString());
                string nom = fila[1].ToString();

                Asignatura a = new Asignatura(cod,nom);

                lAsignaturas.Add(a);
            }

            return lAsignaturas;
        }

        public int ObtenerProximoID()
        {
            return DBHelper.ObtenerInstancia().ObtenerProximoId("sp_proximo_id","@next");
        }
    }
}
