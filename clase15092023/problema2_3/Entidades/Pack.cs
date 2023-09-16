using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema2_3.Entidades
{
    public class Pack : Producto
    {
        public int Cantidad { get; set; }

        public Pack(int codigo,string nombre,double precio,int cantidad) 
            : base(codigo,nombre,precio)
        {
            Cantidad= cantidad;
        }

        public override double CalcularPrecio()
        {
            return Cantidad * Precio;
        }
        
        public override string ToString() {

            return "Pack: "+ base.ToString();
            
        }
    }
}
