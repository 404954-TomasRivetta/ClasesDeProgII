using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos.Interfaz
{
    public interface IPresupuestoDAO
    {
        //Obtenemos el proximo presupuesto
        int ObtenerProximoNro();

        //Lo realizamos porque no hacemos un Producto DAO, que seria lo correcto, ya que es propio de producto
        List<Producto> ObtenerProductos();

        //Creamos el presupuesto
        bool Crear(Presupuesto oPresupuesto);
        bool Actualizar(Presupuesto oPresupuesto);


        /*----REALIZAR COMO TAREA(SI SALE)----*/
        //ACTUALIZAR
        //BORRAR
        //LISTA DE PRESUPUESTO CON FILTRO
    }
}
