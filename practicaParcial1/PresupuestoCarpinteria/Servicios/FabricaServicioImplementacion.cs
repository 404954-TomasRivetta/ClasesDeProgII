using PresupuestoCarpinteria.Servicios.implementacion;
using PresupuestoCarpinteria.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCarpinteria.Servicios
{
    public class FabricaServicioImplementacion : FabricaServicio
    {
        public override IServicio CrearServicio()
        {
            return new Servicio();
        }
    }
}
