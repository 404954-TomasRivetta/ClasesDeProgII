using RecetasSLN.dominio;
using System.Data;

namespace RecetasSLN.datos
{
        interface IRecetasDAO
    {
        DataTable ListarIngredientes();
        int ProximaReceta();
        bool EjecutarInsert(Receta oReceta);

    }
}