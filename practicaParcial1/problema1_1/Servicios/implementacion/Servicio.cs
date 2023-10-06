using problema1_1.Datos.implementacion;
using problema1_1.Datos.interfaz;
using problema1_1.Entidades;
using problema1_1.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Servicios.implementacion
{
    public class Servicio : IServicio
    {
        private ICarreraDAO dao;

        public Servicio()
        {
            dao = new CarreraDAO();
        }

        public bool CrearCarrera(Carrera oCarrera)
        {
            return dao.CrearCarrera(oCarrera);
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            return dao.ObtenerAsignaturas();
        }

        public int ObtenerProximoID()
        {
            return dao.ObtenerProximoID();
        }
    }
}
