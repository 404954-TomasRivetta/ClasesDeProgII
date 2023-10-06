using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Entidades
{
    public class DetalleCarrera
    {
        public Asignatura Asignatura { get; set; }

        public int AnioCursado { get; set; }
            
        public int Cuatrimestre { get; set; }

        public DetalleCarrera(Asignatura asignatura, int anioCursado,int cuatrimestre )
        { 
            Asignatura = asignatura;
            AnioCursado = anioCursado;
            Cuatrimestre = cuatrimestre;
        }
    }
}
