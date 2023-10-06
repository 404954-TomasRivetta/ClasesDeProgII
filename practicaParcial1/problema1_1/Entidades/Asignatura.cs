using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Entidades
{
    public class Asignatura
    {
        public int CodAsignatura { get; set; }

        public string NombreAsignatura { get; set; }

        public Asignatura(int codAsignatura,string nombreAsignatura)
        {
            CodAsignatura = codAsignatura;
            NombreAsignatura= nombreAsignatura;
        }

        public override string ToString()
        {
            return NombreAsignatura; 
        }

    }
}
