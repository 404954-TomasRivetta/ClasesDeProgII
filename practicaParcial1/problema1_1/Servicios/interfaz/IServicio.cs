using problema1_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Servicios.interfaz
{
    public interface IServicio
    {

        List<Asignatura> ObtenerAsignaturas();

        int ObtenerProximoID();

        bool CrearCarrera(Carrera oCarrera);


    }
}
