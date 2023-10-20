using Microsoft.AspNetCore.Mvc;
using Problema42.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Problema42.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        //privado para que el usuairo no pueda verla
        //static para poder heredar
        //readonly para que sea solo lectura 
        private static readonly List<Moneda> lMonedas = new List<Moneda>();


        // GET: api/<CashController>
        [HttpGet]
        public IActionResult Get() //siempre IActionResult cuando es un HttpGet() ya que devolvemos un codigo de estado
        {
            return Ok(lMonedas);
        }

        // GET api/<CashController>/dolar
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach (Moneda m in lMonedas)
            {
                if (m.Nombre.Equals(nombre)) //m.Nombre == nombre
                {
                    return Ok(m);

                }
            }
            return NotFound("Moneda no registrada"); //COD 404, error cliente
        }

        // POST api/<CashController>
        [HttpPost]
        public IActionResult Post([FromBody] Moneda moneda)
        {
            //ACA REALIZO UNA VERIFICACION, PERO ESTAS VERIFICACIONES NO SE HACEN ACA
            if (moneda==null || string.IsNullOrEmpty(moneda.Nombre))
            {
                return BadRequest("Moneda incorrecta..."); // COD 400, error cliente
            }
            lMonedas.Add(moneda); //CARGO LA MONEDA EN LA LISTA
            return Ok(moneda); //MANDO LA MONEDA QUE SE CREO
        }

        // PUT api/<CashController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CashController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        //CLICK DERECHO EN CARPETA, AGREGAR NUEVO ELEMENTO 'WEB', controlador de api: con acciones de lectura y escritura

    }
}
