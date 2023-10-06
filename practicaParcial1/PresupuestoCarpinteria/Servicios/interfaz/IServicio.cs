using PresupuestoCarpinteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Servicios.interfaz
{
    public interface IServicio
    {
        List<Producto> ObtenerProductos();

        int ObtenerProximoID();

        bool CrearPresupuesto(Presupuesto oPresupuesto);

        List<Presupuesto> ObtenerPresupuestosFiltrados(DateTime fechaDesde, DateTime fechaHasta, string cliente);

        bool BorrarOrden(int nroOrden);
    }
}
