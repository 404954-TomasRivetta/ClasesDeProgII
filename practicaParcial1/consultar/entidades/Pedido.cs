using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultar.entidades
{
    public class Pedido
    {
        public int Codigo { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string DireccionEntrega { get; set; }

        public string Entregado { get; set; }

        public DateTime FechaBaja { get; set; }

        public int CodCliente { get; set; }

        public Pedido(int codigo,
            DateTime fechaEntrega,
            string direccionEntrega,
            string entregado,
            DateTime fechaBaja,
            int codCliente)
        {
            this.Codigo = codigo;
            this.FechaEntrega = fechaEntrega;
            this.DireccionEntrega = direccionEntrega;
            this.Entregado = entregado;
            this.FechaBaja = fechaBaja;
            CodCliente = codCliente;
        }

        public Pedido()
        {
            Codigo = 0;
            FechaEntrega = DateTime.Now;
            DireccionEntrega = string.Empty;
            Entregado = string.Empty;
            FechaBaja = DateTime.Now;
            CodCliente = 0;
        }
    }
}
