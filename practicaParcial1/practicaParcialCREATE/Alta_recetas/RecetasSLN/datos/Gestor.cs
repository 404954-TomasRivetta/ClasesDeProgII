using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.datos;
using RecetasSLN.dominio;

namespace RecetasSLN.datos
{
    class Gestor
    {

        private IRecetasDAO dao;

        public DataTable ListarIngredientes()
        {
            dao = new RecetasDAO();
            return dao.ListarIngredientes();
        }

        public int ProximaReceta()

        {
            dao = new RecetasDAO();
            return dao.ProximaReceta();
        }

        public bool EjecutarInsert(Receta oReceta)
        {
            return dao.EjecutarInsert(oReceta);
        }
    }
}
