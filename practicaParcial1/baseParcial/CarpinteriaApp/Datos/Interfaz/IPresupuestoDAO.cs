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

        //ACTUALIZAR presupuesto
        bool Actualizar(Presupuesto oPresupuesto);
        Presupuesto ObtenerPresupuestoPorNumero(int numero); // va en conjunto con el actualizar poruqe cuando lo presione al boton actualizar me va a mandar de vuelta al form de nuevo presupuesto con la data del presupuesto al que le hice click

        //BORRAR presupuesto - update de la fecha de baja
        bool Borrar(int numero);

        //LISTA DE PRESUPUESTO CON FILTRO
        List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime fechaDesde, DateTime fechaHasta, string cliente);


    }
}
