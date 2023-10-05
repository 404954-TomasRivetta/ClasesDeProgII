using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    class Ingrediente
    {

        public int IngredienteID { get; set; }
        public string Nombre { get; set; }
        //public string UnidadMedida { get; set; }
        public Ingrediente(int ingredienteID, string nombre) //string unidadMedida)
        {
            IngredienteID = ingredienteID;
            this.Nombre = nombre;
            //this.UnidadMedida = unidadMedida;
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
