using problema2_3.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema2_3.Entidades
{
    public abstract class Producto : IProducto
    {

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(int codigo,string nombre, double precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }

        //PORQUE NOSE SI ES UN PACK O SUELTO, entonces le hago un metodo abstracto
        //LO DELEGO A LAS clases HIJAS
        public abstract double CalcularPrecio();

        public override string ToString()
        {
            return Codigo + " - " + Nombre + " - $" + CalcularPrecio();
        }

        //public virtual double CalcularPrecio() {
        //    return Precio;
        //}

    }
}
