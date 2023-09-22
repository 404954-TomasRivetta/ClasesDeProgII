using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios.Interfaz
{
    public interface IServicio
    {
        int TraerProximoNro();
        List<Producto> TraerProductos();
        bool GrabarPresupuesto(Presupuesto oPresupuesto);
    }
}
