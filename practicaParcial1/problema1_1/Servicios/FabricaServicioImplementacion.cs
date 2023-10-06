using problema1_1.Servicios.implementacion;
using problema1_1.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema1_1.Servicios
{
    public class FabricaServicioImplementacion : FabricaServicio
    {
        public override IServicio CrearServicio()
        {
            return new Servicio();
        }
    }
}
