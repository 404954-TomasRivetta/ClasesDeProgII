using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema2_3.Entidades
{
    public class Suelto : Producto
    {
        public int Medida { get; set; }

        public Suelto(int codigo, string nombre, double precio, int medida) : base(codigo, nombre, precio)
        {
            Medida = medida;
        }

        public override double CalcularPrecio()
        {
            return Medida * Precio;
        }

        public override string ToString()
        {
            return "Suelto: " + base.ToString();
        }

    }
}
