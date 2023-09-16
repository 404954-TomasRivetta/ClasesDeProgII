using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema2_3.Entidades.Interfaces
{

    //LAS INTERFACES SOLO TIENEN METODOS PUBLICOS Y ABSTRACTOS Y VIENE ABSTRACTA POR DEFAULT
    public interface IProducto
    {
        double CalcularPrecio();
        //aca tipico entraria los metodos CRUD
        //acumulo metodos
    }
}
