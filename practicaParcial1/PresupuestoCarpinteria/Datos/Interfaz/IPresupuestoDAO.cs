using PresupuestoCarpinteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Datos.Interfaz
{
    public interface IPresupuestoDAO
    {
        List<Producto> ObtenerProductos();

        int ObtenerProximoID();

        bool CrearPresupuesto(Presupuesto oPresupuesto);

        List<Presupuesto> ObtenerPresupuestosFiltrados(DateTime fechaDesde,DateTime fechaHasta,string cliente);

        bool BorrarOrden(int nroOrden);

    }
}
