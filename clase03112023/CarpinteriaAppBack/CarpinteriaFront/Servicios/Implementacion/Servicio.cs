using CarpinteriaBack.Datos.Implementacion;
using CarpinteriaBack.Datos.Interfaz;
using CarpinteriaBack.Entidades;
using CarpinteriaFront.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaFront.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IPresupuestoDao dao;
        public Servicio()
        {
            dao = new PresupuestoDao();
        }
        public bool CrearPresupuesto(Presupuesto oPresupuesto)
        {
           return dao.Crear(oPresupuesto);
        }

        public List<Presupuesto> TraerPresupuestosFiltrados(DateTime value1, DateTime value2, string text)
        {
            throw new NotImplementedException();
        }

        public List<Producto> TraerProductos()
        {
            return dao.ObtenerProductos();
        }

        public int TraerProximoPresupuesto()
        {
            return dao.ObtenerProximoPresupuesto(); 
        }

    }
}
