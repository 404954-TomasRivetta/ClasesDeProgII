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

        bool BorrarPedido(int nro);

        bool EntregarPedido(int nro);

    }
}
