
using PruebaTecnicaAPIEF.Contexto;
using PruebaTecnicaAPIEF.Models;

namespace PruebaTecnicaAPIEF.Services
{
    public class TrabajadorService: ITrabajadorService
    {
        private readonly IContextoDB _contextoDB;

        public TrabajadorService(IContextoDB contextoDB)
        {
            this._contextoDB = contextoDB;
        }

        public void AddTrabajador(Trabajador trabajador)
        {
            _contextoDB.Trabajadores.Add(trabajador);
            _contextoDB.SaveChanges();
        }

        public void DeleteTrabajador(Trabajador trabajador)
        {
            _contextoDB.Trabajadores.Remove(trabajador);
            _contextoDB.SaveChanges();
        }

        public List<Trabajador> GetTrabajadors()
        {
            return _contextoDB.Trabajadores.Select(x => x).ToList();
        }

        public Trabajador GetTrabajador(int trabajadorId)
        {
            return _contextoDB.Trabajadores.Where(x => x.IdUsuario == trabajadorId).FirstOrDefault();
        }

        public Trabajador UpdatedTrabajador(Trabajador trabajador)
        {
            var existingTrabajador = _contextoDB.Trabajadores.Find(trabajador.IdUsuario);
            if (existingTrabajador == null)
            {
                // La entidad no existe en la base de datos
                return null;
            }

            // Copiar los valores modificados a la entidad existente
            _contextoDB.Trabajadores.Entry(existingTrabajador).CurrentValues.SetValues(trabajador);

            // Guardar los cambios en la base de datos
            _contextoDB.SaveChanges();

            return existingTrabajador;
        }
    }
}