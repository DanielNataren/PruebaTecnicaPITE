using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPIEF.Models;

namespace PruebaTecnicaAPIEF.Contexto
{
    public class ContextoDB: DbContext, IContextoDB
    {
        public DbSet<Trabajador> Trabajadores {get; set;}

        public ContextoDB(DbContextOptions<ContextoDB> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajador>().HasKey(t => t.IdUsuario);

        }
    }
}