using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Data;
using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
       
    public class TrabajadorController : ControllerBase
    {
        
        // GET api/<controller>
        [HttpGet]
        public List<Trabajador> Get()
        {
            return TrabajadorData.Listar();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Trabajador Get([FromRoute] int id)
        {
            Console.WriteLine(id);
            return TrabajadorData.Obtener(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Trabajador Post([FromBody]Trabajador oTrabajador)
        {
            return TrabajadorData.Registrar(oTrabajador);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Trabajador Put( [FromRoute] int id, [FromBody]Trabajador oTrabajador)
        {
            return TrabajadorData.Modificar(id, oTrabajador);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string Delete([FromRoute] int id)
        {
            TrabajadorData.Eliminar(id);
            return "Usuario eliminado";
        }
    }
}