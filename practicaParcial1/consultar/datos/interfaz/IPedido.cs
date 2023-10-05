using consultar.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultar.datos.interfaz
{
    public interface IPedido
    {
        List<Cliente> TraerClientes();

        List<Pedido> TraerPedidosFiltrados(DateTime fechaDesde, DateTime fechaHasta, int codCliente);

        void BorrarPedido(int nro);

        void EntregarPedido(int nro);

    }
}
