﻿using consultar.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultar.Servicios.interfaz
{
    public interface IServicio
    {
        List<Cliente> TraerClientes();

        List<Pedido> TraerPedidosFiltrados(DateTime fechaDesde,DateTime fechaHasta,int codCliente );

        void BorrarOrden(int nro);

        void EntregarPedido(int nro);
    }
}
