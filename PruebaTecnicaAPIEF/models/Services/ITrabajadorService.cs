

using PruebaTecnicaAPIEF.Models;

namespace PruebaTecnicaAPIEF.Services
{
    public interface ITrabajadorService
    {
        void AddTrabajador(Trabajador trabajador);
        void DeleteTrabajador(Trabajador trabajador);
        List<Trabajador> GetTrabajadors();
        Trabajador GetTrabajador(int trabajadorId);
        Trabajador UpdatedTrabajador(Trabajador trabajador);
    }
}