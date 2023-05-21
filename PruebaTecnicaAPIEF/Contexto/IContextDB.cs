
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPIEF.Models;

namespace PruebaTecnicaAPIEF.Contexto
{
    public interface IContextoDB {
        DbSet<Trabajador> Trabajadores {get; set;}
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}