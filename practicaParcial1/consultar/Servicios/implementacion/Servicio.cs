using consultar.datos;
using consultar.datos.implementacion;
using consultar.datos.interfaz;
using consultar.entidades;
using consultar.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultar.Servicios.implementacion
{
    public class Servicio : IServicio
    {

        private IPedido dao;

        public Servicio() {

            dao = new PedidoDAO();
            
        }

        public bool BorrarOrden(int nro)
        {
            return dao.BorrarPedido(nro);
        }

        public bool EntregarPedido(int nro)
        {
            return dao.EntregarPedido(nro);
        }

        public List<Cliente> TraerClientes()
        {
            return dao.TraerClientes();
        }

        public List<Pedido> TraerPedidosFiltrados(DateTime fechaDesde, DateTime fechaHasta, int codCliente)
        {
            return dao.TraerPedidosFiltrados(fechaDesde,fechaHasta,codCliente);
        }
    }
}
