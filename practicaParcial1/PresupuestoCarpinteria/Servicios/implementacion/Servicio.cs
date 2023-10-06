using PresupuestoCarpinteria.Datos.Implementacion;
using PresupuestoCarpinteria.Datos.Interfaz;
using PresupuestoCarpinteria.Entidades;
using PresupuestoCarpinteria.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Servicios.implementacion
{
    public class Servicio : IServicio
    {

        private IPresupuestoDAO dao;

        public Servicio()
        {
            dao = new PresupuestoDAO();
        }

        public bool CrearPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.CrearPresupuesto(oPresupuesto);
        }

        public List<Producto> ObtenerProductos()
        {
            return dao.ObtenerProductos();
        }

        public int ObtenerProximoID()
        {
            return dao.ObtenerProximoID();
        }
        public List<Presupuesto> ObtenerPresupuestosFiltrados(DateTime fechaDesde, DateTime fechaHasta, string cliente)
        {
            return dao.ObtenerPresupuestosFiltrados(fechaDesde, fechaHasta, cliente);
        }

        public bool BorrarOrden(int nroOrden)
        {
            return dao.BorrarOrden(nroOrden);
        }
    }
}
