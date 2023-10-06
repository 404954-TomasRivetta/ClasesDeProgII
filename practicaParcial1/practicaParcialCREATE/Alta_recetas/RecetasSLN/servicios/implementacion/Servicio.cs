using RecetasSLN.datos.Implementacion;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.dominio;
using RecetasSLN.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios.implementacion
{
    public class Servicio : IServicio
    {

        private IRecetaDAO dao;

        public Servicio()
        {
            dao = new RecetaDAO();
        }

        public bool CrearReceta(Receta oReceta)
        {
            return dao.CrearReceta(oReceta);
        }

        public List<Ingrediente> TraerIngredientes()
        {
            return dao.TraerIngredientes();
        }

        public int TraerProximoIdReceta()
        {
            return dao.TraerProximoIdReceta();
        }
    }
}
