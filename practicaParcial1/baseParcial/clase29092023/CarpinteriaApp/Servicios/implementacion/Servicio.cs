using CarpinteriaApp.Datos.implementaciones;
using CarpinteriaApp.Datos.Interfaz;
using CarpinteriaApp.Entidades;
using CarpinteriaApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios.implementacion
{
    public class Servicio : IServicio
    {
        private IPresupuestoDAO dao;

        public Servicio()
        {
            dao = new PresupuestoDAO();
        }

        public int TraerProximoNro()
        {
            return dao.ObtenerProximoNro();
        }

        public List<Producto> TraerProductos()
        {
            return dao.ObtenerProductos();
        }

        public bool GrabarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.Crear(oPresupuesto);
        }

        public bool ModificarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.Actualizar(oPresupuesto);
        }

        public List<Presupuesto> TraerPresupuestosFiltrados(DateTime fechaDesde, DateTime fechaHasta, string cliente)
        {
            return dao.ObtenerPresupuestosPorFiltros(fechaDesde, fechaHasta, cliente);
        }
    }
}
