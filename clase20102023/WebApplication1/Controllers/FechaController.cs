using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //DECORADORES - Para definir como lo voy a invocar y que ruta seguir
    [Route("api/[controller]")] // api/Fecha
    //[Route("[controller]")] // /Fecha
    [ApiController]
    public class FechaController : ControllerBase
    {
        //ESTO ES UN ENDPOINT
        //COMO VOY A HACER LA LLAMADA
        [HttpGet] //EL TIPO IActionResult Sirve para recibir el codigo HTTP que me devuelve, lo voy a tener que usar cada vez que quiera poner usar HttpGet
        public IActionResult Get()
        {
            return Ok(new Fecha());
        }


        //CLICK DERECHO EN CARPETA, AGREGAR NUEVO ELEMENTO 'WEB', controlador de api: blanco
    }
}
