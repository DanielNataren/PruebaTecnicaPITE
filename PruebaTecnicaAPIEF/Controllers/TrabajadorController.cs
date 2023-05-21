using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPIEF.Models;
using PruebaTecnicaAPIEF.Services;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
       
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService _trabajadorService;
        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }
        
        // GET api/<controller>
        [HttpGet]
        public ActionResult<List<Trabajador>> Get()
        {
            List<Trabajador> trabajadors = _trabajadorService.GetTrabajadors();
            return trabajadors;
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get([FromRoute] int id)
        {
            Trabajador trabajador = _trabajadorService.GetTrabajador(id);
            if (trabajador == null){
                return "No se encontró el usuBario";
            }
            return trabajador;
        }

        [HttpPost]
        public ActionResult<Trabajador> Post([FromBody]Trabajador oTrabajador)
        {
            Trabajador trabajador = new Trabajador{
                DocumentoIdentidad = "5141426272",
                Ciudad = "Madrid",
                Correo = "danielflonat@gmail.com",
                FechaRegistro = DateTime.Now,
                Nombres = "KEvin Daniel",
                Telefono = "96154416123"
            };
            _trabajadorService.AddTrabajador(trabajador);

            return trabajador;
        }

        [HttpPut("{id}")]
        public ActionResult<object> Put( [FromRoute] int id, [FromBody]Trabajador oTrabajador)
        {
            oTrabajador.IdUsuario = id;
            Trabajador oldTrabajord = _trabajadorService.GetTrabajador(id);
            if (oldTrabajord == null){
                return "No se encontró el usuario";
            }
            oTrabajador.FechaRegistro = oldTrabajord.FechaRegistro;
            Trabajador trabajador = _trabajadorService.UpdatedTrabajador(oTrabajador);
            return trabajador;
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute] int id)
        {
            Trabajador trabajador = _trabajadorService.GetTrabajador(id);
            if (trabajador == null){
                return "No se encontró el usuario";
            }
            _trabajadorService.DeleteTrabajador(trabajador);
            return $"Usuario {trabajador.Nombres} eliminado";
        }
    }
}