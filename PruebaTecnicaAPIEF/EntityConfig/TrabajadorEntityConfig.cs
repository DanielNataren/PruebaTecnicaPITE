

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaAPIEF.Models;

namespace PruebaTecnicaAPIEF.EntityConfig
{
    public class TrabajadorEntityConfig
    {
        public static void SetTrabajadorEntityConfig(EntityTypeBuilder<Trabajador> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuario);
            entityBuilder.Property(x => x.DocumentoIdentidad).IsRequired();
            entityBuilder.Property(x => x.Ciudad).IsRequired();
            entityBuilder.Property(x => x.Nombres).IsRequired();
            entityBuilder.Property(x => x.Telefono).IsRequired();
            entityBuilder.Property(x => x.Correo).IsRequired();
            entityBuilder.Property(x => x.FechaRegistro).IsRequired();
        }
    }
}