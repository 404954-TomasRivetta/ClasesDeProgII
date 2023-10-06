using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Entidades
{
    public class Carrera
    {
        public int CodCarrera { get; set; }

        public string NombreCarrera { get; set; }

        public string TituloCarrera { get; set; }

        public List<DetalleCarrera> Detalles { get; set; }


        public Carrera()
        {
            Detalles = new List<DetalleCarrera>();
        }

        public void AgregarDetalle(DetalleCarrera detalle) {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int posicion) {
            Detalles.RemoveAt(posicion);
        }
    }
}
